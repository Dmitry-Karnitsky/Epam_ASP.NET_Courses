using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbersCalculation
{
    public class FibonacciNumbers
    {
        public static IEnumerable<long> Find(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("Number");
            if (number == 0)
                return new long[0];
            return Searcher(number);
        }

        private static IEnumerable<long> Searcher(int number)
        {
            yield return 1;
            long result = 0;
            int k = 0;
            long returned1 = 0;
            long returned2 = 1;
            while (result <= long.MaxValue / 1.5 && k < number - 1)
            {
                yield return result = returned1 + returned2;
                k++;
                returned1 = returned2;
                returned2 = result;
            }
        }
    }
}
