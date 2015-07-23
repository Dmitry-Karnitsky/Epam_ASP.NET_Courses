using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchHelper
{
    public static class BinarySearchHelper
    {
        public static int CustomBinarySearch<T>(this T[] array, T value)
        {
            if (array == null)
                throw new NullReferenceException("array");

            if (value != null)
            {
                bool comparable = value is IComparable;

                if (comparable == true)
                {
                    return CustomBinarySearch(array, value, (T t1, T t2) => { return ((IComparable)t1).CompareTo(t2); });
                }
                else throw new InvalidOperationException("Type " + typeof(T).ToString() + " is not comparable type.");
            }
            else throw new InvalidOperationException("Not able to find null object.");
        }
        
        public static int CustomBinarySearch<T>(this T[] array, T value, Func<T, T, int> comparer)
        {
            if (array == null)
                throw new NullReferenceException("array");
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            
            int lo = array.GetLowerBound(0);
            int hi = array.GetUpperBound(0);

            if (hi < 0) 
                throw new ArgumentException("Invalid array lenght.");

            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int order;
                try
                {
                    order = comparer(array[i], value);
                }
                catch(Exception e)
                {
                    throw new ArgumentException("Comparer not valid.", e);
                }

                if (order == 0) return i;
                if (order < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }

            return ~lo;
        }
    }
}
