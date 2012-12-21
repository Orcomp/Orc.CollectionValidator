namespace Orc.CollectionValidator.SpecificValidators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ItemValidationResult : ValidationResult
    {
        public Dictionary<int, FluentValidation.Results.ValidationFailure[]> Errors { get; set; }
    }
}
