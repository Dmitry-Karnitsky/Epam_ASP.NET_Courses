using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public class GeneralMatrix<T> : IMatrix<T>, IEquatable<IMatrix<T>>
    {
        public virtual event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        protected T[,] Matrix { get; set; }

        #region Properties (IMatrix<T> implicit interface implementation)

        public virtual T this[int i, int j]
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

                ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("GeneralMatrix", temp, value, i, j);
                OnElementChanged(eventArgs);
            }
        }

        public int Rows { get { return Matrix.GetLength(0); } }
        public int Columns { get { return Matrix.GetLength(1); } }

        #endregion

        #region Constructors
        // It's protected and empty for implicit chain call by compiler
        // without passing matrix throughout all constructors
        protected GeneralMatrix() { }

        // Constructor for creating a matrix class
        public GeneralMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("SquareMatrix");
            // No properties to check in regualar matrix
            // That's why this method always return true.
            CheckMatrixProperties(matrix);

            this.Matrix = matrix;
        }

        #endregion

        #region Protected virtual methods for checking matrix properties

        // Method for checking matrix properties.
        // If it's return false, new class with this matrix won't be created,
        // because passed matrix does not satisfy the condition of this concrete class
        protected virtual bool CheckMatrixProperties(T[,] matrix)
        {
            return true;
        }

        // Derrived classes can override checking methods and create new,
        // that will satisfy the logic of concrete derived class 

        #endregion

        public bool Equals(IMatrix<T> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.Columns != this.Columns || other.Rows != this.Rows)
                return false;

            for (int i = 0; i < other.Rows; i++)
            {
                for (int j = 0; j < other.Columns; j++)
                {
                    if (this[i, j].Equals(other[i, j]) == false)
                        return false;
                }
            }
            return true;
        }       

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }
    }
}
