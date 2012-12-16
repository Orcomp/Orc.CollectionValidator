using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orc.CollectionValidator
{
    public abstract class AbstractCollectionValidator<T> : ICollectionValidator<T>
    {
        protected readonly string errorMessage = "Collection is not valid";

        public AbstractCollectionValidator(string errorMessage = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                this.errorMessage = errorMessage;
            }
        }

        public abstract ValidationResults Validate(IEnumerable<T> collection);
    }
}
