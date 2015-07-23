using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelperRefactored
{
    public class DiagonalMatrix<T> : SymmetricalMatrix<T>
    {
        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Order || j < 0 || j >= Order)
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                    return Matrix[i];
                else
                    return default(T);
            }
            set
            {
                if (i < 0 || i >= Order || j < 0 || j >= Order)
                    throw new ArgumentOutOfRangeException();
                T temp;
                if (i == j)
                {
                    temp = Matrix[i];
                    Matrix[i] = value;

                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("DiagonalMatrix: changed element on main diagonal.", temp, value, i, j);
                    OnElementChanged(eventArgs);
                }
                else
                {
                    temp = default(T);                    
                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("DiagonalMatrix: can't change non main diagonal element.", temp, temp, i, j);
                    OnElementChanged(eventArgs);
                }
            }
        }

        #region Constructors

        protected DiagonalMatrix(int order) 
            : base(order, order, null) { }

        public DiagonalMatrix(T[,] matrix)
            : base(matrix.GetLength(0), matrix.GetLength(0), matrix) { }
        
        #endregion

        #region Protected virtual methods for checking matrix properties

        protected override bool CheckMatrixProperties(T[,] matrix)
        {
            return CheckIsSquareMatrix(matrix) && CheckIsSymmetrical(matrix) && CheckIsDiagonalMatrix(matrix);
        }

        protected virtual bool CheckIsDiagonalMatrix(T[,] matrix)
        {
            bool isDiagonal = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (matrix[i, j].Equals(default(T)) == false)
                        {
                            isDiagonal = false;
                            return isDiagonal;
                        }
                    }
                }
            return isDiagonal; //true
        }
        #endregion

        protected override void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }
    }
}
