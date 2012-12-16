namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Orc.CollectionValidator.Utilits;

    public class UniqueValidator<T> : AbstractCollectionValidator<T>, ICollectionValidator<T>
    {
        private readonly IEqualityComparer<T> comparer;
        private const string DefaultErrorMessage = "Duplicated items were found in collection";

        public UniqueValidator(string errorMessage = null)
            : base(string.IsNullOrWhiteSpace(errorMessage) ? DefaultErrorMessage : errorMessage)
        {
            this.comparer = EqualityComparer<T>.Default;
        }

        public UniqueValidator(Func<T,T,bool> equals, string errorMessage = null)
            : base(string.IsNullOrWhiteSpace(errorMessage) ? DefaultErrorMessage : errorMessage)
        {
            this.comparer = new ValidationComparer<T>(equals, x => x.GetHashCode());
        }

        public UniqueValidator(Expression<Func<T, object>>[] properties, string errorMessage = null)
            : base(string.IsNullOrWhiteSpace(errorMessage) ? DefaultErrorMessage : errorMessage)
        {
            this.comparer = new ValidationComparer<T>(properties);
        }

        /// <summary>
        /// This function validates collection
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResults"/>.
        /// </returns>
        public override ValidationResults Validate(IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();

            var allDuplicates = new List<int>();
            var groupedDuplicates = new List<int[]>();

            for (var index = 0; index < enumerable.Length; index++)
            {
                var itemDuplicates = enumerable.FindAllIndexes(index + 1, allDuplicates, enumerable[index], this.comparer);
                var duplicates = itemDuplicates as IList<int> ?? itemDuplicates.ToList();
                if (!duplicates.Any())
                {
                    continue;
                }

                allDuplicates.AddRange(duplicates);
                duplicates.Add(index);
                groupedDuplicates.Add(duplicates.OrderBy(x => x).ToArray());
            }

            return allDuplicates.Count == 0
                       ? new ValidationResults(Enumerable.Empty<ValidationResult>())
                       : new ValidationResults(
                             new[]
                                 {
                                     new UniqueValidationResult
                                         {
                                             ErrorMessage = this.errorMessage,
                                             DuplicatedItems = groupedDuplicates.ToArray()
                                         }
                                 });
        }

    }
}
