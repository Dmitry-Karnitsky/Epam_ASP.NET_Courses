using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1;
using Task_2;
using Task_3;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                Console.WriteLine("--- Task 1 Tests ---");
                double testValue_1 = double.MaxValue;
                double testValue_2 = 1 / double.MaxValue;

                NewtonSqrt.Accuracy = testValue_2;
                Console.WriteLine("Sqrt(" + testValue_1.ToString() + ") = " + NewtonSqrt.Sqrt(testValue_1) + " //Newton Method");
                Console.WriteLine("Sqrt(" + testValue_1.ToString() + ") = " + Math.Pow(testValue_1, 0.5) + " //Math.Pow Method");
                Console.WriteLine();
                Console.WriteLine("Sqrt(" + testValue_2.ToString() + ") = " + NewtonSqrt.Sqrt(testValue_2) + " //Newton Method");
                Console.WriteLine("Sqrt(" + testValue_2.ToString() + ") = " + Math.Pow(testValue_2, 0.5) + " //Math.Pow Method");
                Console.WriteLine();
            }

            {
                Console.WriteLine("--- Task 2 Tests ---");
                int[,] matrix = new int[4, 5]{
                                                {4,5,6,4,0},
                                                {1,2,3,7,1},
                                                {8,3,7,4,6},
                                                {1,9,3,2,4}
                };
                Console.WriteLine();
                Console.WriteLine("Matrix before rows sorting:");
                ShowMatrix(matrix);
                Console.WriteLine();

                Console.WriteLine("Matrix's rows sorted by rows sum increasing:");
                matrix.SortRows(SortCriterion.RowSum, SortDirection.Increasing);
                ShowMatrix(matrix);
                Console.WriteLine();

                Console.WriteLine("Matrix's rows sorted by rows lowest element increasing:");
                matrix.SortRows(SortCriterion.LowestRowElement, SortDirection.Increasing);
                ShowMatrix(matrix);
                Console.WriteLine();

                Console.WriteLine("Matrix's rows sorted by rows highest element decreasing:");
                matrix.SortRows(SortCriterion.HighestRowElement, SortDirection.Decreasing);
                ShowMatrix(matrix);
                Console.WriteLine();

            }

            {
                Console.WriteLine("--- Task 3 Tests ---");
                int testValue_1 = int.MaxValue;
                int testValue_2 = int.MinValue;
                int testValue_3 = 5246785;
                int testValue_4 = -23589;
                Console.WriteLine();
                string s = String.Format(new MyFormatProvider(), "{0:hex}", testValue_1);
                Console.WriteLine("MyFormatProvider: " + testValue_1.ToString() + " = " + s);
                Console.WriteLine("Convert.ToString(): " + testValue_1.ToString() + " = " + Convert.ToString(testValue_1, 16));
                Console.WriteLine();
                s = String.Format(new MyFormatProvider(), "{0:hex}", testValue_2);
                Console.WriteLine("MyFormatProvider: " + testValue_2.ToString() + " = " + s);
                Console.WriteLine("Convert.ToString(): " + testValue_2.ToString() + " = " + Convert.ToString(testValue_2, 16));
                Console.WriteLine();
                s = String.Format(new MyFormatProvider(), "{0:hex}", testValue_3);
                Console.WriteLine("MyFormatProvider: " + testValue_3.ToString() + " = " + s);
                Console.WriteLine("Convert.ToString(): " + testValue_3.ToString() + " = " + Convert.ToString(testValue_3, 16));
                Console.WriteLine();
                s = String.Format(new MyFormatProvider(), "{0:hex}", testValue_4);
                Console.WriteLine("MyFormatProvider: " + testValue_4.ToString() + " = " + s);
                Console.WriteLine("Convert.ToString(): " + testValue_4.ToString() + " = " + Convert.ToString(testValue_4, 16));
                Console.ReadKey();
            }
        }

        static void ShowMatrix(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++ )
            {
                for(int j = 0; j < matrix.GetLength(1); j++ )
                {
                    Console.Write(matrix[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
