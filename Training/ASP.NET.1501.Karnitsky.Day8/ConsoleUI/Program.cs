using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomArrayEnumerator;
using FibonacciNumbersCalculation;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            
            double[] elements = new double[] { 7, 1.3, 2.99, 76, 5, 89, 2.5, 3.8, 6.1, 0.3, 8.4 };
            CustomArray<double> array = new CustomArray<double>(elements);

            #region Full Array Print
            {
                Console.WriteLine("CustomArray: ");
                int i = 0;
                foreach (double d in array)
                {
                    Console.WriteLine(String.Format("Index {0}: {1}", i, d));
                    i++;
                }
            }
            Console.WriteLine();
            #endregion

            #region Filter Items
            {   // Using FilterItems extension method 
                Console.WriteLine("Items that satisfy the condition: item < 5");
                foreach (double d in array.FilterItems((double x) => { return x < 5; }))
                {
                    Console.WriteLine(d);
                }
            }
            Console.WriteLine();
            #endregion

            #region Filter Indexes
            {   // Using FilterIndexes instance method
                Console.WriteLine("Items with indexes, that satisfy the condition: x % 2 == 0");
                foreach (double d in array.FilterIndexes((int x) => { return x % 2 == 0; }))
                {
                    Console.WriteLine(d);
                }
            }
            Console.WriteLine();
            #endregion             

            #region Filter Items and Indexes
            {   // Using FilterItems extension method with inxese filtering
                Console.WriteLine("Items that satisfy the condition: item < 5, index < 8");
                foreach (double d in array.FilterItems((double x) => { return x < 5; }, (int x) => {return x % 2 == 0; }))
                {
                    Console.WriteLine(d);
                }
            }
            Console.WriteLine();
            #endregion

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Fibonacci series:");

            foreach(long i in FibonacciNumbers.Find(int.MaxValue / 4))
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
            

        }
    }
}
