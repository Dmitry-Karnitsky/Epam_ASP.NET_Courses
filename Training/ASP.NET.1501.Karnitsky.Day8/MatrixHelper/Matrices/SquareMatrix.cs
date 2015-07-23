using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public class SquareMatrix<T> : GeneralMatrix<T>, ISquareMatrix<T>
    {
        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        #region Properties (ISquareMatrix<T> implicit interface implementation)

        public virtual int Order
        {
            get { return Matrix.GetLength(0); }
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Matrix.GetLength(0) || j < 0 || j >= Matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                return Matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= Matrix.GetLength(0) || j < 0 || j >= Matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                T temp = Matrix[i, j];
                Matrix[i, j] = value;

                ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SquareMatrix", temp, value, i, j);
                OnElementChanged(eventArgs);
            }
        }
        #endregion

        #region Properties (ISquareMatrix<T> explicit interface implementation)
        int IMatrix<T>.Rows { get { return Matrix.GetLength(0); } }
        int IMatrix<T>.Columns { get { return Matrix.GetLength(1); } }
        #endregion

        #region Constructors
        protected SquareMatrix() { }

        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("SquareMatrix");
            if (CheckMatrixProperties(matrix) == false)
                throw new ArgumentException("Matrix isn't a square matrix.");

            this.Matrix = matrix;
        }
        #endregion
        
        #region Protected virtual methods for checking matrix properties
      
        protected override bool CheckMatrixProperties(T[,] matrix)
        {
            return CheckIsSquareMatrix(matrix);
        }

        protected virtual bool CheckIsSquareMatrix(T[,] matrix)
        {
            bool isSquare = false;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                isSquare = true;
                return isSquare;
            }
            isSquare = false;
            return isSquare; //false
        }       
        #endregion

        protected override void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }

    }
}
