namespace Orc.CollectionValidator.SpecificValidators
{
    //using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    using ValidationResult = Orc.CollectionValidator.ValidationResult;

    public class CollectionItemValidator<T> : AbstractCollectionValidator<T>
    {
        private readonly FluentValidation.AbstractValidator<T> validator;

        // TODO: need to create class to replace AbstractValidator<T> in constructor
        public CollectionItemValidator(FluentValidation.AbstractValidator<T> validator)
        {
            this.validator = validator;
        }

        public override ValidationResults Validate(IEnumerable<T> collection)
        {
            return
                new ValidationResults(
                    new ValidationResult[]
                        {
                            new ItemValidationResult
                                {
                                    Errors =
                                        collection.Select(
                                            (item, i) =>
                                            new KeyValuePair
                                                <int, FluentValidation.Results.ValidationResult>(
                                                i, this.validator.Validate(item)))
                                                  .Where(x => x.Value.IsValid)
                                                  .ToDictionary(
                                                      x => x.Key, x => x.Value.Errors.ToArray())
                                }
                        });
        }

        public FluentValidation.IRuleBuilder<T, TProp> CreateRule<TProp>(System.Linq.Expressions.Expression<Func<T, TProp>> property)
        {
            var rule = FluentValidation.Internal.PropertyRule.Create(property, () => this.validator.CascadeMode);
            this.validator.AddRule(rule);
            return new FluentValidation.Internal.RuleBuilder<T, TProp>(rule);
        }
    }
}
