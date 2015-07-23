using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixHelperRefactored;

namespace MatrixHelperRefactoredUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            SymmetricalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(new int[3, 3] { { 10, 0, 0 }, { 0, 4, 0 }, { 0, 0, 15 } });

            Console.WriteLine("Square matrix as a result of addition symmetrical and diagonal ones.");
            AbstractSquareMatrix<int> squareMatrix = MatrixExtensions.SumMatrices(diagonalMatrix, symmetricalMatrix);
            PrintMatrix(squareMatrix);
            Console.WriteLine();

            Console.WriteLine("Square matrix as a result of addition every element with number 4.");
            Subscribe(squareMatrix);
            for (int i = 0; i < squareMatrix.Order; i++)
                for (int j = 0; j < squareMatrix.Order; j++)
                    squareMatrix[i, j] += 4; 
            PrintMatrix(squareMatrix);
            Unsubscribe(squareMatrix);

            Console.WriteLine();
            Console.WriteLine("Diagonal matrix summ with itself.");
            Subscribe(diagonalMatrix);
            PrintMatrix(diagonalMatrix);
            diagonalMatrix.SumWith(diagonalMatrix);
            PrintMatrix(diagonalMatrix);
            Unsubscribe(diagonalMatrix);
            Console.WriteLine();

            Console.WriteLine("Symmetrical matrix sum with itself.");
            Subscribe(symmetricalMatrix);
            PrintMatrix(symmetricalMatrix);
            symmetricalMatrix.SumWith(symmetricalMatrix);
            PrintMatrix(symmetricalMatrix);
            Unsubscribe(symmetricalMatrix);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Subscribe(AbstractSquareMatrix<int> matrix)
        {
            matrix.ElementChanged += ElementChanged;
        }

        static void Unsubscribe(AbstractSquareMatrix<int> matrix)
        {
            matrix.ElementChanged -= ElementChanged;
        }

        static void ElementChanged(object sender, ElementChangedEventArgs<int> e)
        {
            Console.WriteLine(String.Format("Message: \"{0}\", Before: {1}, After: {2}, At: [{3},{4}]", e.Message, e.ElementBefore, e.ElementAfter, e.I, e.J));
        }

        static void PrintMatrix<T>(AbstractSquareMatrix<T> matrix)
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Console.Write(String.Format("{0,2} ", matrix[i, j].ToString()));
                }
                Console.WriteLine();
            }
        }
    }
}
