using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Orc.CollectionValidator.SpecificValidators
{
    public class ItemValidator<T> : AbstractValidator<T>
    {
        public ItemValidator()
        {
        }
    }
}
