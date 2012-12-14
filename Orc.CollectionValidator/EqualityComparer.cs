namespace Orc.CollectionValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Orc.CollectionValidator.Utilits;

    /// <summary>
    /// The equality comparer.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// The equals.
        /// </summary>
        private readonly Func<T, T, bool> equals;

        /// <summary>
        /// The get hash code.
        /// </summary>
        private readonly Func<T, int> getHashCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualityComparer{T}"/> class.
        /// </summary>
        /// <param name="equals">
        /// The equals.
        /// </param>
        /// <param name="getHashCode">
        /// The get hash code.
        /// </param>
        public EqualityComparer(Func<T, T, bool> equals = null, Func<T, int> getHashCode = null)
        {
            if (equals == null)
            {
                this.equals =
                    (x, y) => (x != null && x.Equals(y)) || (y != null && y.Equals(x));
            }
            else
            {
                this.equals = equals;
            }

            if (getHashCode == null)
            {
                this.getHashCode = x => x.GetHashCode();
            }
            else
            {
                this.getHashCode = getHashCode;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualityComparer{T}"/> class.
        /// </summary>
        /// <param name="propExpressions">
        /// The prop expressions.
        /// </param>
        public EqualityComparer(params Expression<Func<T, object>>[] propExpressions)
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
        /// The equals.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(T x, T y)
        {
            return this.equals(x, y);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetHashCode(T obj)
        {
            if (getHashCode == null)
            {
                return obj == null ? 0 : obj.GetHashCode();
            }
            return this.getHashCode(obj);
        }
    }
}
