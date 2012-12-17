namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Main collection validation class.
    /// </summary>
    /// <typeparam name="T">Type of collection elements.
    /// </typeparam>
    public class CollectionValidator<T> : ICollectionValidator<T>
    {
        /// <summary>
        /// The list of validators.
        /// </summary>
        private readonly IList<ICollectionValidator<T>> validators = new List<ICollectionValidator<T>>();
        
 
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
