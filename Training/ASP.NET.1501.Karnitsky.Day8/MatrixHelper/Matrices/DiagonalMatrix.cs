using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public class DiagonalMatrix<T> : SymmetricalMatrix<T>, ISquareMatrix<T>
    {
        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        #region Properties (ISquareMatrix<T> implicit interface implementation)
        
        /* Implementation of virtual property Order is inherited by SymmetricalMatrix<T> class */

        // Overrides set method.
        // Because matrix somebody was created an instance of diagonal matrix, it should stays 
        // diagonal all time to death. That's why, you can't change element outside the main diagonal
        // If you try to do this, nothing will happen.
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

                if (i == j)
                {
                    Matrix[i, j] = value;
                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("DiagonalMatrix: changed element on main diagonal.", temp, value, i, j);
                    OnElementChanged(eventArgs);
                }
                else
                {
                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("DiagonalMatrix: can't change non main diagonal element.", temp, temp, i, j);
                    OnElementChanged(eventArgs);
                }

            }
        }
        #endregion

        #region Properties (ISquareMatrix<T> explicit interface implementation)
        int IMatrix<T>.Rows { get { return Matrix.GetLength(0); } }
        int IMatrix<T>.Columns { get { return Matrix.GetLength(1); } }
        #endregion

        #region Constructors
        protected DiagonalMatrix() { }

        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("DiagonalMatrix");  
            if (CheckMatrixProperties(matrix) == false)
                throw new ArgumentException("Matrix isn't a diagonal matrix.");

            this.Matrix = matrix;
        }
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
