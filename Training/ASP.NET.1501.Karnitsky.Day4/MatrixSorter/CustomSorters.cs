using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelper
{
    public delegate int Compare(int[] a, int[] b);

    public class QuickSorter : ISorter
    {   

        public void Sort(int[][] array, IComparer comparer)
        {
            if (comparer == null || array == null)
                throw new ArgumentNullException("Arguments can't be null.");
            
            QuickSort(array, 0, array.GetLength(0) - 1, comparer.Compare);
        }

        public void Sort(int[][] array, Compare comparer)
        {
            if (comparer == null || array == null)
                throw new ArgumentNullException("Arguments can't be null.");
            
            QuickSort(array, 0, array.GetLength(0) - 1, comparer);
        }

        private void QuickSort(int[][] array, int leftBorder, int rightBorder, Compare comparer)
        {
            while (leftBorder < rightBorder)
            {
                int m = Partition(array, leftBorder, rightBorder, comparer);
                if (m - leftBorder <= rightBorder - m)
                {
                    QuickSort(array, leftBorder, m - 1, comparer);
                    leftBorder = m + 1;
                }
                else
                {
                    QuickSort(array, m + 1, rightBorder, comparer);
                    rightBorder = m - 1;
                }
            }
        }

        private int Partition(int[][] array, int leftBorder, int rightBorder, Compare comparer)
        {
            int pivotIndex = leftBorder + (rightBorder - leftBorder) / 2;
            int[] pivotValue = array[pivotIndex];
            array[pivotIndex] = array[leftBorder];


            int i = leftBorder + 1;
            int j = rightBorder;

            while (true)
            {
                while ((i < j) && (comparer(pivotValue, array[i]) > 0)) i++;
                while ((j >= i) && (comparer(array[j], pivotValue) > 0)) j--;
                if (i >= j) break;
                Swap(array, i, j);
                j--;
                i++;
            }

            array[leftBorder] = array[j];
            array[j] = pivotValue;

            return j;
        }

        private void Swap(int[][] array, int i, int j)
        {
            int[] temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }

    public class BubbleSorter : ISorter
    {
        public void Sort(int[][] array, IComparer comparator)
        {            
            BubbleSort(array);
        }

        public void Sort(int[][] array, Compare comparator)
        {            
            BubbleSort(array);
        }

        private static void BubbleSort(int[][] array)
        {
            throw new NotImplementedException();
        }
    }

}
