using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MathHelper
{
    public class GCD
    {
        public delegate int GCDMethod(int arg1, int arg2);

        #region Calculate Eucledian Static Methods

        public static int CalculateEucledian(int arg1, int arg2)
        {
            long ticks;
            return Calculate(new GCD().EucledianMethod, out ticks, arg1, arg2);
        }

        public static int CalculateEucledian(int arg1, int arg2, int arg3)
        {
            long ticks;
            return Calculate(new GCD().EucledianMethod, out ticks, arg1, arg2, arg3);
        }

        public static int CalculateEucledian(params int[] args)
        {
            long ticks;
            return Calculate(new GCD().EucledianMethod, out ticks, args);
        }

        public static int CalculateEucledian(out long ticks, int arg1, int arg2)
        {
            return Calculate(new GCD().EucledianMethod, out ticks, arg1, arg2);
        }

        public static int CalculateEucledian(out long ticks, int arg1, int arg2, int arg3)
        {
            return Calculate(new GCD().EucledianMethod, out ticks, arg1, arg2, arg3);
        }

        public static int CalculateEucledian(out long ticks, params int[] args)
        {
            return Calculate(new GCD().EucledianMethod, out ticks, args);
        }

        #endregion

        #region Calculate Stein Static Methods

        public static int CalculateStein(int arg1, int arg2)
        {

            long ticks;
            return Calculate(new GCD().SteinMethod, out ticks, arg1, arg2);
        }

        public static int CalculateStein(int arg1, int arg2, int arg3)
        {
            long ticks;
            return Calculate(new GCD().SteinMethod, out ticks, arg1, arg2, arg3);
        }

        public static int CalculateStein(params int[] args)
        {
            long ticks;
            return Calculate(new GCD().SteinMethod, out ticks, args);
        }

        public static int CalculateStein(out long ticks, int arg1, int arg2)
        {
            return Calculate(new GCD().SteinMethod, out ticks, arg1, arg2);
        }

        public static int CalculateStein(out long ticks, int arg1, int arg2, int arg3)
        {
            return Calculate(new GCD().SteinMethod, out ticks, arg1, arg2, arg3);
        }

        public static int CalculateStein(out long ticks, params int[] args)
        {
            return Calculate(new GCD().SteinMethod, out ticks, args);
        }

        #endregion

        #region Calculate by delegate methods

        public static int Calculate(GCDMethod delegateMethod, out long ticks, int arg1, int arg2)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            arg1 = Math.Abs(arg1);
            arg2 = Math.Abs(arg2);

            int result = delegateMethod(arg1, arg2);

            watch.Stop();
            ticks = new TimeSpan(watch.ElapsedTicks).Ticks;

            return result;
        }

        public static int Calculate(GCDMethod delegateMethod, out long ticks, int arg1, int arg2, int arg3)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            arg1 = Math.Abs(arg1);
            arg2 = Math.Abs(arg2);
            arg3 = Math.Abs(arg3);

            int temp = delegateMethod(arg1, arg2);
            temp = delegateMethod(temp, arg3);

            watch.Stop();
            ticks = new TimeSpan(watch.ElapsedTicks).Ticks;

            return temp;
        }

        public static int Calculate(GCDMethod delegateMethod, out long time, params int[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < args.Length - 1; i++)
            {
                args[i] = delegateMethod(Math.Abs(args[i]), Math.Abs(args[i + 1]));
                args[i + 1] = args[i];
            }

            watch.Stop();
            time = new TimeSpan(watch.ElapsedTicks).Ticks;

            return args[args.Length - 1];
        }

        #endregion


        #region Instance Methods

        public int EucledianMethod(int arg1, int arg2)
        {

            if (arg1 == 0) return arg2;
            if (arg2 == 0) return arg1;

            while (arg1 != arg2)
            {
                if (arg1 > arg2)
                {
                    arg1 = arg1 - arg2;
                }
                else
                {
                    arg2 = arg2 - arg1;
                }
            }

            return arg1;
        }

        public int SteinMethod(int arg1, int arg2)
        {
            int power;

            if (arg1 == 0) return arg2; // 1. gcd(0, arg2) = arg2,
            if (arg2 == 0) return arg1; //    gcd(arg1, 0) = arg1,

            // 2. gcd(arg1, arg2) = 2·gcd(arg1/2, arg2/2)
            // if arg1 and arg2 are both even.
            for (power = 0; ((arg1 | arg2) & 1) == 0; ++power)
            {
                arg1 >>= 1;
                arg2 >>= 1;
            }

            // 3. gcd(arg1, arg2) = gcd(arg1/2, arg2)
            // if arg1 is even and arg2 is odd
            while ((arg1 & 1) == 0)
                arg1 >>= 1;

            do
            {
                // 3. gcd(arg1, arg2) = gcd(arg1, arg2/2)
                // if arg2 is even and arg1 is odd
                while ((arg2 & 1) == 0)
                    arg2 >>= 1;

                // Standart Eucledian transpositions
                if (arg1 > arg2)
                {
                    int t = arg2;
                    arg2 = arg1;
                    arg1 = t;
                }
                arg2 = arg2 - arg1;


            } while (arg2 != 0);

            // Power of 2, calculated on second step if both numbers are even.
            arg1 = arg1 << power;

            return arg1;
        }

        #endregion
    }
}
