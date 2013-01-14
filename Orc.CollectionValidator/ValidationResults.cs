namespace Orc.CollectionValidator
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ValidationResults : IEnumerable<ValidationResult>
    {
        private readonly IEnumerable<ValidationResult> validationResults;

        public ValidationResults(IEnumerable<ValidationResult> validationResults)
        {           
            this.validationResults = validationResults;
        }


		public static ValidationResults Success {
			get {
				return new ValidationResults(Enumerable.Empty<ValidationResult>());
			}
		}

		public static ValidationResults Failed(params string[] errors)
		{
			return Failed(errors.Select(error => new ValidationResult{ ErrorMessage = error }));
		}

		public static ValidationResults Failed(IEnumerable<ValidationResult> errors)
		{
			return new ValidationResults(errors);
		}

        public bool IsValid
        {
            get
            {
                return !this.validationResults.Any();
            }
        }

        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return this.validationResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.validationResults).GetEnumerator();
        }
    }
}
