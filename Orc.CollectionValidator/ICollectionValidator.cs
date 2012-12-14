using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orc.CollectionValidator
{
    public interface ICollectionValidator<T>
    {
        ValidationResult Validate(IEnumerable<T> collection);
    }
}
