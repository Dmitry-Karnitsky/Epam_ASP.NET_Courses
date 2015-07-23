using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayEnumerator
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private static T[] array;

        public CustomArray(params T[] elements)
        {
            if (elements == null)
                throw new ArgumentNullException("MyArray");
            array = elements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T elem in array)
            {
                yield return elem;
            }
        }

        public IEnumerable<T> FilterIndexes(Func<int, bool> filter)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (filter(i))
                    yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (array == null)
                throw new ArgumentNullException("GetEnumerator");
            return GetEnumerator();
        }
    }
}
