using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public static class NewtonSqrt
    {
        private static double eps = 0.0001;

        /// <summary>
        /// Can set any value from 0 to 1.
        /// </summary>
        public static double Accuracy
        {
            get { return eps; }
            
            set { eps = (value > 0 && value < 1) ? value : eps; }            
        }

        /// <summary>
        /// Returns the square root of a specified number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Not negative square root of a not negative number.
        /// 
        /// </returns>
        public static double Sqrt(double number)
        {
            if (number < 0) return Double.NaN;

            if (number == 0) return 0;

            double thisIterationNumber = 1;
            double previousIterationNumber;
            double iterationAccuracy = 0;
            do
            {
                previousIterationNumber = thisIterationNumber;
                thisIterationNumber = 0.5*(previousIterationNumber + number/previousIterationNumber);
                iterationAccuracy = Math.Abs(previousIterationNumber - thisIterationNumber);
            }
            while (iterationAccuracy > eps);

            return thisIterationNumber;
        }

    }
}
