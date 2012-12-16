﻿namespace Orc.CollectionValidator
{
    using System.Collections.Generic;

    public interface ICollectionValidator<T>
    {
        ValidationResults Validate(IEnumerable<T> collection);
    }
}
