using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayEnumerator
{
    public static class CustomArrayExtensions
    {
        public static IEnumerable<T> FilterItems<T>(this IEnumerable<T> array, Func<T, bool> itemsFilter)
        {
            if (array == null)
                throw new NullReferenceException("FilterItems");
            if (itemsFilter == null)
                throw new ArgumentNullException("Delegate null exception");
            return FilterInternal(array, itemsFilter, (int x) => { return true; });
        }

        public static IEnumerable<T> FilterItems<T>(this IEnumerable<T> array, Func<T, bool> itemsFilter, Func<int, bool> indexesFilter)            
        {
            if (array == null)
                throw new NullReferenceException("FilterItems");
            if (itemsFilter == null || indexesFilter == null)
                throw new ArgumentNullException("Delegate null exception");

            return FilterInternal(array, itemsFilter, indexesFilter);
        }

        public static IEnumerable<T> FilterInternal<T>(IEnumerable<T> array, Func<T, bool> itemsFilter, Func<int, bool> indexesFilter)
        {
            int i = 0;
            foreach (T elem in array)
            {
                if (indexesFilter(i))
                {
                    if (itemsFilter(elem))
                    {
                        yield return elem;
                    }
                }
                i++;
            }
        }
    }
}
