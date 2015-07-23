using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixHelper;

namespace MatrixHelperUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            GeneralMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(new int[3, 3] { { 10, 0, 0 }, { 0, 4, 0 }, { 0, 0, 15 } });

            Subscribe(symmetricalMatrix);
            symmetricalMatrix.SumWith(diagonalMatrix, (int x, int y) => { return x + y; });
            Console.WriteLine();
            PrintMatrix(symmetricalMatrix);
            Unsubscribe(symmetricalMatrix);

            Console.WriteLine();
            Subscribe(diagonalMatrix);
            diagonalMatrix.SumWith(symmetricalMatrix, (int x, int y) => { return x + y; });
            PrintMatrix(diagonalMatrix);
            Unsubscribe(diagonalMatrix);

            Console.WriteLine();

            GeneralMatrix<int> generalMatrix1 = new GeneralMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            GeneralMatrix<int> generalMatrix2 = new GeneralMatrix<int>(new int[3, 3] { { 10, 0, 0 }, { 0, 4, 0 }, { 0, 0, 15 } });
            
            Subscribe(generalMatrix1);
            generalMatrix1.SumWith(generalMatrix2, (int x, int y) => { return x + y; });
            Console.WriteLine();
            PrintMatrix(generalMatrix1);
            Unsubscribe(generalMatrix1);


            Console.ReadLine();
        }

        static void Subscribe(GeneralMatrix<int> matrix)
        {
            matrix.ElementChanged += ElementChanged;
        }

        static void Unsubscribe(GeneralMatrix<int> matrix)
        {
            matrix.ElementChanged -= ElementChanged;
        }

        static void ElementChanged(object sender, ElementChangedEventArgs<int> e)
        {
            Console.WriteLine(String.Format("Message: \"{0}\", Before: {1}, After: {2}, At: [{3},{4}]", e.Message, e.ElementBefore, e.ElementAfter, e.I, e.J));
        }

        static void PrintMatrix<T>(IMatrix<T> matrix)
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write(String.Format("{0,2} ", matrix[i, j].ToString()));
                }
                Console.WriteLine();
            }
        }
    }
}
