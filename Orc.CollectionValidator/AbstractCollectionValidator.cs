namespace Orc.CollectionValidator
{
    using System.Collections.Generic;
    using Orc.CollectionValidator.Interfaces;

    /// <summary>
    /// Base class for all collection validators
    /// </summary>
    /// <typeparam name="T">Type of collection elements.
    /// </typeparam>
    public abstract class AbstractCollectionValidator<T> : ICollectionValidator<T>
    {
        /// <summary>
        /// The error message.
        /// </summary>
        protected readonly string ErrorMessage = "Collection is not valid";

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractCollectionValidator{T}"/> class.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        protected AbstractCollectionValidator(string errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                this.ErrorMessage = errorMessage;
            }
        }

        /// <summary>
        /// Validates collection
        /// </summary>
        /// <param name="collection">
        /// Collection to validate
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResults"/>.
        /// </returns>
        public abstract ValidationResults Validate(IEnumerable<T> collection);
    }
}
