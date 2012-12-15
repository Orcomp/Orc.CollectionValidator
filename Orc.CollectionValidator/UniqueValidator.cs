namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Orc.CollectionValidator.Utilits;

    public class UniqueValidator<T> : ICollectionValidator<T>
    {
        private readonly IEqualityComparer<T> comparer;

        private readonly string errorMessage = "Not all objects incollection are unique";

        public UniqueValidator(string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.errorMessage = errorMessage;
            }
            this.comparer = new ValidationComparer<T>();
        }

        public UniqueValidator(Func<T,T,bool> equals, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.errorMessage = errorMessage;
            }
            this.comparer = new ValidationComparer<T>(equals, x => x.GetHashCode());
        }

        public UniqueValidator(Expression<Func<T, object>>[] properties, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.errorMessage = errorMessage;
            }
            this.comparer = new ValidationComparer<T>(properties);
        }

        /// <summary>
        /// This function validates collection
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        public ValidationResult Validate(IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            /* 
            foreach (var item in enumerable)
            {
                enumerable.GetAllIndexes(item, this.comparer);
            }            
            */
            var distinctCount = this.comparer == null
                              ? enumerable.Distinct().Count()
                              : enumerable.Distinct(this.comparer).Count();
            
            var count = enumerable.Count();
            var isValid = distinctCount == count;
            return new ValidationResult
                       {
                           ErrorMessages = isValid ? new string[0] : new[] { this.errorMessage },
                           IsValid = isValid
                       };
        }

    }
}
