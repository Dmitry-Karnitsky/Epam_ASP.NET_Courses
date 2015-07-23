using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelperRefactored
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        private int order;

        protected virtual T[] Matrix { get; set; }

        public override event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        public override int Order
        {
            get { return order; }
            protected set { order = value; }
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= order || j < 0 || j >= order)
                    throw new ArgumentOutOfRangeException();
                return Matrix[i * Order + j];
            }
            set
            {
                if (i < 0 || i >= order || j < 0 || j >= order)
                    throw new ArgumentOutOfRangeException();
                T temp = Matrix[i * Order + j];
                Matrix[i * Order + j] = value;

                ElementChangedEventArgs<T> eventArgs = new ElementChangedEventArgs<T>("SquareMatrix", temp, value, i, j);
                OnElementChanged(eventArgs);
            }
        }

        protected SquareMatrix(int baseArrayCapacity, int order, T[,] matrix)
        {
            if (order < 0)
                throw new ArgumentOutOfRangeException("Matrix order can not be negative.");

            if (matrix != null)
            {
                if (CheckMatrixProperties(matrix) == false)
                    throw new ArgumentException("Martix does not satisfy the conditions.");
            }
            InitializeMatrix(baseArrayCapacity, order, matrix);
        }

        public SquareMatrix(int order) : this(order * order, order, null) { }

        public SquareMatrix(T[,] matrix) : this(matrix.GetLength(0) * matrix.GetLength(0), matrix.GetLength(0), matrix) { }

        protected void InitializeMatrix(int baseArrayCapacity, int order, T[,] matrix)
        {
            Matrix = new T[baseArrayCapacity];
            Order = order;
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    if (matrix == null)
                        this[i, j] = default(T);
                    else
                        this[i, j] = matrix[i, j];
                }
            }
        }

        protected virtual bool CheckMatrixProperties(T[,] matrix)
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

        protected override void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            e.Raise<ElementChangedEventArgs<T>>(this, ref ElementChanged);
        }

    }
}
