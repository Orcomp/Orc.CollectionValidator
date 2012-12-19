namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Orc.CollectionValidator.Interfaces;

    public class WrappedCollectionValidator<T> : IWrappedCollectionValidator, IFluentCollectionValidator<WrappedCollectionValidator<T>, T>
    {
        private readonly CollectionValidator<T> validator;

        private readonly IEnumerable<T> collection; 

        internal WrappedCollectionValidator(IEnumerable<T> collection)
        {
            this.collection = collection;
            this.validator = new CollectionValidator<T>();
        }

        public WrappedCollectionValidator<T> Unique(string errorMessage = null, params Expression<Func<T, object>>[] properties)
        {
            this.validator.Unique(errorMessage, properties);
            return this;
        }

        public WrappedCollectionValidator<T> CountGreaterThan(int count, string errorMessage = null)
        {
            this.validator.CountGreaterThan(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountLessThan(int count, string errorMessage = null)
        {
            this.validator.CountLessThan(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountGreaterOrEqualTo(int count, string errorMessage = null)
        {
            this.validator.CountGreaterOrEqualTo(count, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> CountLessOrEqualTo(int count, string errorMessage = null)
        {
            this.validator.CountLessOrEqualTo(count);
            return this;
        }

        public WrappedCollectionValidator<T> CountCondition(Predicate<int> condition, string errorMessage = null)
        {
            this.validator.CountCondition(condition, errorMessage);
            return this;
        }

        public WrappedCollectionValidator<T> Single()
        {
            this.validator.Single();
            return this;
        }

        public ValidationResults Validate()
        {
            return this.validator.Validate(this.collection);
        }
    }
}
