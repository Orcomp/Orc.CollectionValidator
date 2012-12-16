namespace Orc.CollectionValidator.Utilits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class ArrayExtension
    {
        public static IEnumerable<int> FindAllIndexes<T>(this T[] array, int startFrom, IEnumerable<int> skipIndexes, T item, IEqualityComparer<T> comparer=null)
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
    }
}
