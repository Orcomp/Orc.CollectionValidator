namespace Orc.CollectionValidator.SpecificValidators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;
    using FluentValidation.Internal;
    using FluentValidation.Results;

    using ValidationResult = Orc.CollectionValidator.ValidationResult;

    public class ElementValidator<T> : AbstractCollectionValidator<T>
    {
        public ElementValidator(string errorMessage = null)
            : base(string.IsNullOrEmpty(errorMessage) ? "One or more items of collections contained failed data." : errorMessage)
        {
        
        }

        private  IList<AbstractValidator<T>> otherValidators = new List<AbstractValidator<T>>();

        private readonly AbstractValidator<T> propertyValidator = new InlineValidator<T>();

        private readonly AbstractValidator<ElementWrapper<T>> itemValidator = new InlineValidator<ElementWrapper<T>>();

		public override ValidationResults Validate(IEnumerable<T> collection)
		{
			var result = new ItemValidationResult
							 {
								 ErrorMessage = this.ErrorMessage,
								 Errors =
									 collection.Select(
										 (item, i) =>
										 new KeyValuePair<int, IEnumerable<ValidationFailure>>(
											 i, this.ValidateItem(item)))
											   .Where(x => x.Value.Any())
											   .ToDictionary(x => x.Key, x => x.Value.ToArray())
							 };
			return result.Errors.Count == 0 ? ValidationResults.Success : new ValidationResults(new ValidationResult[] { result });
		}

        public IRuleBuilder<T, TProp> CreatePropertyRule<TProp>(System.Linq.Expressions.Expression<Func<T, TProp>> property)
        {
            var rule = PropertyRule.Create(property, () => this.propertyValidator.CascadeMode);
            this.propertyValidator.AddRule(rule);
            return new RuleBuilder<T, TProp>(rule);
        }

        public IRuleBuilder<ElementWrapper<T>, T> CreateRule()
        {
            var rule = PropertyRule.Create<ElementWrapper<T>, T>(x => x.Element, () => this.itemValidator.CascadeMode);
            this.itemValidator.AddRule(rule);
            return new RuleBuilder<ElementWrapper<T>, T>(rule);
        }

        internal void AddValidator(AbstractValidator<T> validator)
        {
            otherValidators.Add(validator);
        }

        private IEnumerable<ValidationFailure> ValidateItem(T item)
        {
            var errors = new List<ValidationFailure>();

            var result = this.itemValidator.Validate(new ElementWrapper<T> { Element = item });
            if (!result.IsValid)
            {
                errors.AddRange(result.Errors);
            }

            if (item != null)
            {
                result = this.propertyValidator.Validate(item);
                if (!result.IsValid)
                {
                    errors.AddRange(result.Errors);
                }                

                foreach (var otherValidator in this.otherValidators)
                {
                    result = otherValidator.Validate(item);
                    if (!result.IsValid)
                    {
                        errors.AddRange(result.Errors);
                    }
                }
            }

            return errors.Distinct().ToArray();
        }

        public void SetErrorMessage(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
