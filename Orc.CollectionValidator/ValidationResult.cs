namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string[] ErrorMessages { get; set; }
    }
}
