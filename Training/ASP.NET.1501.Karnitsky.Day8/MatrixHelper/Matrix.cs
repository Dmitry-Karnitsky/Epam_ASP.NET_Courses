using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MatrixHelper
{
    // Don't used anywhere. Written only for me as a template.
    public class CustomMatrix<T>
    {
        private readonly T[][] matrix;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };        

        #region Constructors

        private CustomMatrix() { }
        public CustomMatrix(T[][] matrix)
        {
            this.matrix = matrix;
            CheckMatrixProperties();
        }

        #endregion        

        #region Properties

        public bool IsSquareAndZero { get; private set; }

        public bool IsSymmetrical { get; private set; }

        public bool IsDiagonal { get; private set; }

        public bool IsZeroAndZero { get; private set; }
        #endregion        

        #region Matrix properties check methods

        private void CheckMatrixProperties()
        {
            if (CheckIsSquareMatrix())
            {
                IsSquareAndZero = true;
                if (CheckIsSquareAndZeroMatrix())
                {
                    IsSquareAndZero = true;
                    IsDiagonal = true;
                    IsSymmetrical = true;
                }
                else
                {
                    IsSquareAndZero = false;
                    if (CheckIsDiagonalMatrix())
                    {
                        IsDiagonal = true;
                        IsSymmetrical = true;
                    }
                    else
                    {
                        IsDiagonal = false;
                        if (CheckIsSymmetrical())
                        {
                            IsSymmetrical = true;
                        }
                        else
                            IsSymmetrical = false;
                    }
                }
            }
            else
            {
                IsSquareAndZero = false;
                IsSymmetrical = false;
                IsDiagonal = false;
                IsSquareAndZero = false;
            }
        }

        private bool CheckIsSquareMatrix()
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

        private bool CheckIsSquareAndZeroMatrix()
        {
            if (CheckIsSquareMatrix() == false)
            {
                return false;
            }

            bool isZero = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i][i].Equals(default(T)) == false)
                {
                    isZero = false;
                    return isZero;
                }
            }

            return isZero; //true
        }

        private bool CheckIsDiagonalMatrix()
        {
            bool isDiagonal = true;
            for(int i = 0; i < matrix.GetLength(0); i++)
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (matrix[i][j].Equals(default(T)) == false)
                        {
                            isDiagonal = false;
                            return isDiagonal;
                        }
                    }                        
                }
            return isDiagonal; //true
        }

        private bool CheckIsSymmetrical()
        {           
           bool isSymmetrical = true; 
           for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if(matrix[i][j].Equals(matrix[j][i]) == false)
                    {
                        isSymmetrical = false;
                        return isSymmetrical;
                    }
                }
           return isSymmetrical; // true
        }


        #endregion

        public T this[int i, int j]
        {            
            get 
            {
                if (i < 0 ||i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                return matrix[i][j];
            }
            set 
            {
                if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                T temp = matrix[i][j];
                matrix[i][j] = value;

                ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("TestClass",temp, value, i, j);
                OnElementChanged(eventArgs);
            }
        }

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }

    }    
}
