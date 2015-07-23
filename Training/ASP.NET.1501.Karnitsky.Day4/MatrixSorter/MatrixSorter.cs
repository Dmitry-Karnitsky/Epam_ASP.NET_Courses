using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public static class MatrixSorter
    {

        public static void Sort(this int[][] array, ISorter sorter, IComparer comparator)
        {
            if (array == null)
                throw new NullReferenceException();
            if (sorter == null || comparator == null)
                throw new ArgumentNullException();

            sorter.Sort(array, comparator);
        }

        public static void Sort(this int[][] array, ISorter sorter, Compare comparator)
        {
            if (array == null)
                throw new NullReferenceException();
            if (sorter == null || comparator == null)
                throw new ArgumentNullException();

            sorter.Sort(array, comparator);
        }
    }
}
