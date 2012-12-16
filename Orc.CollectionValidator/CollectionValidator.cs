namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Orc.CollectionValidator.Exceptions;
    using System.Linq.Expressions;

    public class CollectionValidator<T> : ICollectionValidator<T>
    {
        private readonly IList<ICollectionValidator<T>> validators = new List<ICollectionValidator<T>>();

        public CollectionValidator<T> Unique(string errorMessage = null)
        {
            this.validators.Add(new UniqueValidator<T>(errorMessage));
            return this;
        }

        public CollectionValidator<T> Unique(params Expression<Func<T, object>>[] properties)
        {
            this.validators.Add(new UniqueValidator<T>(properties));
            return this;
        }

        public CollectionValidator<T> Unique(string errorMessage, params Expression<Func<T, object>>[] properties)
        {
            this.validators.Add(new UniqueValidator<T>(properties, errorMessage));
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

        public ValidationResults Validate(IEnumerable<T> collection)
        {
            return
                new ValidationResults(
                    this.validators.Select(validator => validator.Validate(collection))
                        .SelectMany(varRes => varRes)
                        .ToArray());

        }        
    }
}
