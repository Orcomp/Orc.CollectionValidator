namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Orc.CollectionValidator.Exceptions;
    using System.Linq.Expressions;

    public class CollectionValidator<T> : ICollectionValidator<T>
    {
        private IList<ICollectionValidator<T>> validators = new List<ICollectionValidator<T>>();

        public CollectionValidator<T> Unique()
        {
            this.validators.Add(new UniqueValidator<T>());
            return this;
        }

        public CollectionValidator<T> Unique(params Expression<Func<T, object>>[] properties)
        {
            this.validators.Add(new UniqueValidator<T>(properties));
            return this;
        }

        public ValidationResult Validate(IEnumerable<T> collection)
        {
            var messages =
                this.validators.Select(validator => validator.Validate(collection).ErrorMessages)
                    .SelectMany(msgList => msgList)
                    .ToArray();
            return new ValidationResult { IsValid = messages.Length == 0, ErrorMessages = messages };
        }
    }
}
