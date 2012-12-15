namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Orc.CollectionValidator.Utilits;

    /// <summary>
    /// Defines methods to support the comparison of objects for equality.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.
    /// </typeparam>
    public class ValidationComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// The equals function to compare objects.
        /// </summary>
        private readonly Func<T, T, bool> equals;

        /// <summary>
        /// The hash code function to compare objects.
        /// </summary>
        private readonly Func<T, int> getHashCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationComparer{T}"/> class.
        /// </summary>
        /// <param name="equals">
        /// The equals function to compare objects.
        /// </param>
        /// <param name="getHashCode">
        /// The hash code function to compare objects.
        /// </param>
        public ValidationComparer(Func<T, T, bool> equals = null, Func<T, int> getHashCode = null)
        {
            if (equals == null)
            {
                this.equals =
                    (x, y) => (x != null && x.Equals(y)) || (y != null && y.Equals(x)) || (x == null && y == null);
            }
            else
            {
                this.equals = equals;
            }

                this.getHashCode = getHashCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationComparer{T}"/> class.
        /// </summary>
        /// <param name="propExpressions">
        /// Lambda expressions described the properties to compare.
        /// </param>
        public ValidationComparer(params Expression<Func<T, object>>[] propExpressions)
        {
            if (propExpressions == null)
            {
                throw new ArgumentNullException("propExpressions");
            }

            var properties = propExpressions.Select(ExpressionAnalizer.GetProppertyInfo).ToArray();
            this.equals = (x, y) => !(from propertyInfo in properties
                                      let xVal = propertyInfo.GetValue(x, null)
                                      let yVal = propertyInfo.GetValue(y, null)
                                      where (xVal != null && !xVal.Equals(yVal)) || (yVal != null && !yVal.Equals(xVal))
                                      select xVal).Any();
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">
        /// The first object to compare.
        /// </param>
        /// <param name="y">
        /// The second object to compare.
        /// </param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(T x, T y)
        {
            return this.equals(x, y);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="Object"/> for which a hash code is to be returned.
        /// </param>
        /// <returns>
        /// 0 if the hash function is not defined; otherwise the result of hash function.
        /// </returns>
        public int GetHashCode(T obj)
        {
            if (this.getHashCode == null)
            {
                return 0;
            }

            return this.getHashCode(obj);
        }
    }
}
