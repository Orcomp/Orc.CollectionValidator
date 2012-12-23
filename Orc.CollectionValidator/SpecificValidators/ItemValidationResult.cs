namespace Orc.CollectionValidator.SpecificValidators
{
    using System.Collections.Generic;

    public class ItemValidationResult : ValidationResult
    {
        public Dictionary<int, FluentValidation.Results.ValidationFailure[]> Errors { get; set; }
    }
}
