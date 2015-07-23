using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelperRefactored
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Order || j < 0 || j >= Order)
                    throw new ArgumentOutOfRangeException();

                if (i > j)
                {
                    i = i + j;
                    j = i - j;
                    i = i - j;
                }

                int row = (2 * Order - i + 1) * i / 2;
                int col = j - i;

                return Matrix[row + col];
            }
            set
            {
                if (i < 0 || i >= Order || j < 0 || j >= Order)
                    throw new ArgumentOutOfRangeException();
                T temp;
                if (i != j)
                {
                    if (i > j)
                    {
                        i = i + j;
                        j = i - j;
                        i = i - j;
                    }

                    int row = (2 * Order - i + 1) * i / 2;
                    int col = j - i;

                    temp = Matrix[row + col];
                    Matrix[row + col] = value;

                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SymmetricalMatrix: changed both symmetric and requested elements.", temp, value, i, j);
                    OnElementChanged(eventArgs);
                }
                else
                {
                    int index = (2 * Order - i + 1) * i / 2;

                    temp = Matrix[index];
                    Matrix[index] = value;

                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SymmetricalMatrix: changed element on main diagonal.", temp, value, i, j);
                    OnElementChanged(eventArgs);
                }
            }
        }

        #region Constructors

        protected SymmetricalMatrix(int baseArrayCapacity, int order, T[,] matrix)
            : base(baseArrayCapacity, order, matrix) { }

        public SymmetricalMatrix(int order)
            : base((2 * order + order) / 2, order, null) { }

        public SymmetricalMatrix(T[,] matrix) : base((matrix.GetLength(0) * matrix.GetLength(0) + matrix.GetLength(0)) / 2, matrix.GetLength(0), matrix) { }

        #endregion

        #region Protected virtual methods for checking matrix properties

        protected override bool CheckMatrixProperties(T[,] matrix)
        {
            return CheckIsSquareMatrix(matrix) && CheckIsSymmetrical(matrix);
        }

        protected virtual bool CheckIsSymmetrical(T[,] matrix)
        {
            bool isSymmetrical = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j].Equals(matrix[j, i]) == false)
                    {
                        isSymmetrical = false;
                        return isSymmetrical;
                    }
                }
            return isSymmetrical; // true
        }

        #endregion

        protected override void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }
    }
}
