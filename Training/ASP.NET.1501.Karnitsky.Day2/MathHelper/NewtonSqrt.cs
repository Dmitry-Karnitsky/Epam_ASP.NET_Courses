using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MathHelper
{
    public static class NewtonSqrt
    {
        private static double eps = 0.00000001;

        public static double Accuracy
        {
            get { return eps; }

            set { eps = (value > 0 && value < 1) ? value : eps; }
        }

        public static double Sqrt(double number, double power)
        {
            if (power < 1)
            {
                throw new ArgumentException();
            }

            if (number < 0 && power % 2 == 0) return Double.NaN;
            if (number == 0) return 0;  

            TimeSpan time;            
            return NewtonSqrt.Sqrt(number, power, out time);
        }

        public static double Sqrt(double number, double power, out TimeSpan time)
        {
            if (power < 1)
            {
                throw new ArgumentException();
            } 

            time = new TimeSpan(0);           
            if (number < 0 && power % 2 == 0) return Double.NaN;
            if (number == 0) return 0;      

            double thisIterationNumber = 1;
            double previousIterationNumber;
            double iterationAccuracy = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            do
            {
                previousIterationNumber = thisIterationNumber;
                thisIterationNumber = (double)(1 / power) * (previousIterationNumber * (power - 1) + number / Sqr(previousIterationNumber, power - 1));
                iterationAccuracy = Math.Abs(previousIterationNumber - thisIterationNumber);
            }
            while (iterationAccuracy > eps);
            watch.Stop();

            time = new TimeSpan(watch.ElapsedTicks);    

            return thisIterationNumber;
        }

        private static double Sqr(double number, double power)
        {
            double result = 1.0;
            while (power != 0)
            {
                if (power % 2 != 0)
                {
                    result *= number;
                    power -= 1;
                }
                number *= number;
                power /= 2;
            }
            return result;
        }
    }
}
