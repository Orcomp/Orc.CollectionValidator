namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using FluentValidation.Internal;

    using Orc.CollectionValidator.Interfaces;
using FluentValidation;
    using Orc.CollectionValidator.SpecificValidators;

    /// <summary>
    /// Main collection validation class.
    /// </summary>
    /// <typeparam name="T">Type of collection elements.
    /// </typeparam>
    public class CollectionValidator<T> : ICollectionValidator<T>, IFluentCollectionValidator<CollectionValidator<T>, T>
    {
        /// <summary>
        /// The list of validators.
        /// </summary>
        private readonly IList<ICollectionValidator<T>> validators = new List<ICollectionValidator<T>>();

        private CollectionItemValidator<T> itemValidator;
        
 
        /// <summary>
        /// Adds UniqueValidator to validation sequence.
        /// </summary>
        /// <param name="errorMessage">
        /// The error Message.
        /// </param>
        /// <param name="properties">
        /// Set of key properties to check uniqueness of collection item.
        /// </param>
        /// <returns>
        /// The <see cref="CollectionValidator"/>.
        /// </returns>
        public CollectionValidator<T> Unique(string errorMessage = null, params Expression<Func<T, object>>[] properties)
        {
            this.validators.Add(
                properties.Any()
                    ? new UniqueValidator<T>(properties, errorMessage)
                    : new UniqueValidator<T>(errorMessage));
            return this;
        }
       
        public CollectionValidator<T> CountGreaterThan(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i > count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountLessThan(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i < count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountGreaterOrEqualTo(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i >= count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountLessOrEqualTo(int count, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(i => i <= count, errorMessage));
            return this;
        }

        public CollectionValidator<T> CountCondition(Predicate<int> condition, string errorMessage = null)
        {
            this.validators.Add(new CountValidator<T>(condition, errorMessage));
            return this;
        }

        public CollectionValidator<T> Single()
        {
            this.validators.Add(new CountValidator<T>(x => x == 1));
            return this;
        }

        public CollectionValidator<T> ElementValidation(AbstractValidator<T> validator)
        {
            if (this.itemValidator == null)
            {
                CreateItemValidator(validator);
            }
            else
            {
                throw new NotImplementedException();
            }
            return this;
        }

        public CollectionValidator<T> ElementValidation<TProp>(Expression<Func<T, TProp>> property, Func<IRuleBuilder<T, TProp>, IRuleBuilderOptions<T, TProp>> validationRules)
        {
            if (this.itemValidator == null)
            {
                CreateItemValidator(new ItemValidator<T>());                
            }

            validationRules(this.itemValidator.CreateRule(property));

            return this;
        }

        private void CreateItemValidator(AbstractValidator<T> validator)
        {
            this.itemValidator = new CollectionItemValidator<T>(validator);
            this.validators.Add(this.itemValidator);
        }

        public ValidationResults Validate(IEnumerable<T> collection)
        {
            if (validators.Count == 0)
                throw new InvalidOperationException("Collection validator not configured.");
            return
                new ValidationResults(
                    this.validators.Select(validator => validator.Validate(collection))
                        .SelectMany(varRes => varRes)
                        .ToArray());

        }        
    }
}
