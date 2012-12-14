namespace Orc.CollectionValidator.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CollectionValidatorException : Exception
    {
        public CollectionValidatorException()
        {
        }

        public CollectionValidatorException(string message)
            : base(message)
        {
        }

        public CollectionValidatorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
