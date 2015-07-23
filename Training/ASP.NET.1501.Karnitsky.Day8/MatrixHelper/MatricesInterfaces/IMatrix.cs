using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public interface IMatrix<T>
    {
        T this[int i, int j] { get; set; }
        int Rows { get; }
        int Columns { get; }
    }
}
