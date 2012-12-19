namespace Orc.CollectionValidator.Utilits
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class Extensions
    {
        public static WrappedCollectionValidator<T> BuildValidator<T>(this IEnumerable<T> collection)
        {
            return new WrappedCollectionValidator<T>(collection);
        }

        /// <summary>
        /// Searches all indexes of duplicated objects
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="startFrom">
        /// The start from.
        /// </param>
        /// <param name="skipIndexes">
        /// The skip indexes.
        /// </param>
        /// <param name="item">
        /// Pattern to compare with other items in collection. 
        /// </param>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <typeparam name="T">Type of objects in collection.
        /// </typeparam>
        /// <returns>
        /// The indexes of duplicated objects.
        /// </returns>
        internal static IEnumerable<int> FindAllIndexes<T>(this T[] array, int startFrom, IEnumerable<int> skipIndexes, T item, IEqualityComparer<T> comparer = null)
        {
            var result = new List<int>();
            for (var i = startFrom; i < array.Length; i++)
            {
                if (skipIndexes.Contains(i))
                {
                    continue;
                }
                    
                if ((comparer == null && array[i] != null && array[i].Equals(item))
                    || (comparer == null && item != null && item.Equals(array[i]))
                    || (item == null && array[i] == null)
                    || (comparer != null && comparer.Equals(item, array[i])))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets <see cref="PropertyInfo"/> from property expression
        /// </summary>
        /// <param name="propertyExpression">
        /// The property expression.
        /// </param>
        /// <typeparam name="T">Type of object.
        /// </typeparam>
        /// <typeparam name="TProp">The property type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="PropertyInfo"/>.
        /// </returns>
        internal static PropertyInfo GetProppertyInfo<T, TProp>(this Expression<Func<T, TProp>> propertyExpression)
        {
            MemberExpression body;
            var expression = propertyExpression.Body as UnaryExpression;
            if (expression != null)
            {
                var unaryBody = expression;
                body = unaryBody.Operand as MemberExpression;
            }
            else
            {
                body = propertyExpression.Body as MemberExpression;
            }

            Debug.Assert(body != null, "body != null");

            return typeof(T).GetProperty(body.Member.Name);
        }
    }
}
