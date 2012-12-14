using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orc.CollectionValidator.Utilits
{
    internal static class ArrayExtension
    {
        public static IEnumerable<int> FindAllIndexes<T>(this T[] array, int startFrom, IEnumerable<int> skipIndexes, T item, IEqualityComparer<T> comparer=null)
        {
            List<int> result = new List<int>();
            for (var i = startFrom; i < array.Length; i++)
            {
                var enumerable = skipIndexes as IList<int> ?? skipIndexes.ToList();
                if (enumerable.Contains(i))
                {
                    continue;
                }

                if ((comparer == null && array[i] != null && array[i].Equals(item))
                    || (comparer == null && item != null && item.Equals(array[i]))
                    || (comparer == null && item == null && array[i] == null))
                {
                }
            }

            throw new NotImplementedException();
        }
    }
}
