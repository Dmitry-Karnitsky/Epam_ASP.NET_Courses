using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{

    public class MinElementsIncreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return 1;
            if (a.Length == 0 && b.Length != 0) return -1;

            return a.Min().CompareTo(b.Min());
        }
    }

    public class MaxElementsIncreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return 1;
            if (a.Length == 0 && b.Length != 0) return -1;

            return a.Max().CompareTo(b.Max());
        }
    }

    public class MinElementsDecreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return -1;
            if (a.Length == 0 && b.Length != 0) return 1;
            return b.Min().CompareTo(a.Min());
        }
    }

    public class MaxElementsDecreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return -1;
            if (a.Length == 0 && b.Length != 0) return 1;
            return b.Max().CompareTo(a.Max());
        }
    }

    public class ElementsSumIncreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;           
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return 1;
            if (a.Length == 0 && b.Length != 0) return -1;
            
            return a.Sum().CompareTo(b.Sum());
        }
    }

    public class ElementsSumDecreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return -1;
            if (a.Length == 0 && b.Length != 0) return 1;

            return b.Sum().CompareTo(a.Sum());
        }
    }

    public class MaxAbsElementsIncreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return 1;
            if (a.Length == 0 && b.Length != 0) return -1;

            int aMaxAbs = FindMaxAbs(a);
            int bMaxAbs = FindMaxAbs(b);
            return aMaxAbs.CompareTo(bMaxAbs);
        }

        private static int FindMaxAbs(int[] arr)
        {
            int arrMaxAbs = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > arrMaxAbs)
                {
                    arrMaxAbs = Math.Abs(arr[i]); 
                }
            }
            return arrMaxAbs;
        }
    }

    public class MaxAbsElementsDecreasing : IComparer
    {
        int IComparer.Compare(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return -1;
            if (a.Length == 0 && b.Length != 0) return 1;

            int aMaxAbs = FindMaxAbs(a);
            int bMaxAbs = FindMaxAbs(b);

            return bMaxAbs.CompareTo(aMaxAbs);
        }

        private static int FindMaxAbs(int[] arr)
        {
            int arrMaxAbs = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > arrMaxAbs)
                {
                    arrMaxAbs = Math.Abs(arr[i]);
                }
            }
            return arrMaxAbs;
        }
    }

    public static class Comparators
    {
        public static int CompareRowsLengthIncreasing(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return 1;
            if (a == null && b != null) return -1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return 1;
            if (a.Length == 0 && b.Length != 0) return -1;            

            return a.Length.CompareTo(b.Length);
        }

        public static int CompareRowsLengthDecreasing(int[] a, int[] b)
        {
            if (a == null && b == null) return 0;
            if (a != null && b == null) return -1;
            if (a == null && b != null) return 1;
            if (a.Length == 0 && b.Length == 0) return 0;
            if (a.Length != 0 && b.Length == 0) return -1;
            if (a.Length == 0 && b.Length != 0) return 1;

            return b.Length.CompareTo(a.Length);
        }
    }

}
