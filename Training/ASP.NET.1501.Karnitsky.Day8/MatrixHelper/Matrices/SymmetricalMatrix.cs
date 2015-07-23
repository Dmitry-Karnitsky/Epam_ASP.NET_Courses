using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>, ISquareMatrix<T>
    {
        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        #region Properties (ISquareMatrix<T> implicit interface implementation)

        /* Implementation of virtual property Order is inherited by SymmetricalMatrix<T> class */

        // Overrides set method.
        // Because matrix somebody was created an instance of symmetrical matrix, it should stays 
        // symmetrical all time to death. That's why, if you change the element not on the main 
        // diagonal, the symmetrical element will change either.
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
                if (i != j)
                {
                    Matrix[i, j] = value;
                    Matrix[j, i] = value;
                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SymmetricalMatrix: changed both symmetric and request elements.", temp, value, i, j);
                    OnElementChanged(eventArgs);
                }
                else
                {
                    Matrix[i, j] = value;
                    ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SymmetricalMatrix: changed element on main diagonal.", temp, value, i, j);
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
        protected SymmetricalMatrix() { }

        public SymmetricalMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("SymmetricalMatrix");  
            if (CheckMatrixProperties(matrix) == false)
                throw new ArgumentException("Matrix isn't a symmetrical matrix.");
            this.Matrix = matrix;
        }
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
