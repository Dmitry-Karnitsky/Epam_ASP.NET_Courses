using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public interface IComparer
    {
        int Compare(int[] a, int[] b);
    }
}
