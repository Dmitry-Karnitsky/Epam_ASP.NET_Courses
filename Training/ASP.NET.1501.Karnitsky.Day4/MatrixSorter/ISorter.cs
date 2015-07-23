using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public interface ISorter
    {
        void Sort(int[][] array, IComparer comparator);
        void Sort(int[][] array, Compare comparer);
    }
}
