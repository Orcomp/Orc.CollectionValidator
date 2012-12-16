namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CountValidator<T> : AbstractCollectionValidator<T>, ICollectionValidator<T>
    {
        private readonly Predicate<int> countValidator;
        private const string DefaultErrorMessage = "Invalid collection items count";

        public CountValidator(Predicate<int> countValidator, string errorMessage = null)
            : base(string.IsNullOrWhiteSpace(errorMessage) ? DefaultErrorMessage : errorMessage)
        {
            this.countValidator = countValidator;
        }

        public override ValidationResults Validate(IEnumerable<T> collection)
        {
            return this.countValidator(collection.Count())
                       ? new ValidationResults(new[] { new ValidationResult { ErrorMessage = errorMessage } })
                       : new ValidationResults(Enumerable.Empty<ValidationResult>());
        }
    }
}
