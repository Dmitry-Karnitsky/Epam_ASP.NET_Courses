using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public enum SortCriterion
    {
        RowSum,
        LowestRowElement,
        HighestRowElement
    }

    public enum SortDirection
    {
        Increasing,
        Decreasing,
    }

    public static class MatrixSorter
    {
        private static int[] matrixRowsKeys;
        private static int[][] jaggedArray;
        private static SortDirection sortDirection;

        public static void SortRows(this int[,] matrix, SortCriterion sortCriterion, SortDirection sortDirection)
        {
            TranformFromMatrixToJaggedArray(matrix);
            matrixRowsKeys = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (sortCriterion == SortCriterion.RowSum)
                    matrixRowsKeys[i] = jaggedArray[i].Sum();

                if (sortCriterion == SortCriterion.HighestRowElement)
                    matrixRowsKeys[i] = jaggedArray[i].Max();

                if (sortCriterion == SortCriterion.LowestRowElement)
                    matrixRowsKeys[i] = jaggedArray[i].Min();
            }

            MatrixSorter.sortDirection = sortDirection;
            SortRowsByKeys();

            TranformFromJaggedArrayToMatrix(matrix);
        }

        public static void SortByRowsSum(int[,] matrix, SortDirection sortDirection)
        {
            TranformFromMatrixToJaggedArray(matrix);
            matrixRowsKeys = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixRowsKeys[i] = jaggedArray[i].Sum();
            }

            MatrixSorter.sortDirection = sortDirection;
            SortRowsByKeys();

            TranformFromJaggedArrayToMatrix(matrix);
        }

        public static void SortByRowsLowestElement(int[,] matrix, SortDirection sortDirection)
        {
            TranformFromMatrixToJaggedArray(matrix);
            matrixRowsKeys = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixRowsKeys[i] = jaggedArray[i].Min();
            }

            MatrixSorter.sortDirection = sortDirection;
            SortRowsByKeys();

            TranformFromJaggedArrayToMatrix(matrix);
        }

        public static void SortByRowsHighestElement(int[,] matrix, SortDirection sortDirection)
        {
            TranformFromMatrixToJaggedArray(matrix);
            matrixRowsKeys = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixRowsKeys[i] = jaggedArray[i].Max();
            }

            MatrixSorter.sortDirection = sortDirection;
            SortRowsByKeys();

            TranformFromJaggedArrayToMatrix(matrix);
        }

        private static void TranformFromMatrixToJaggedArray(int[,] matrix)
        {
            jaggedArray = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                jaggedArray[i] = new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    jaggedArray[i][j] = matrix[i, j];
                }
            }
        }

        private static void TranformFromJaggedArrayToMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        private static void SortRowsByKeys()
        {
            QuickSort(matrixRowsKeys, 0, matrixRowsKeys.Length - 1);
        }

        private static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            while (leftBorder < rightBorder)
            {
                int m = Partition(array, leftBorder, rightBorder);
                if (m - leftBorder <= rightBorder - m)
                {
                    QuickSort(array, leftBorder, m - 1);
                    leftBorder = m + 1;
                }
                else
                {
                    QuickSort(array, m + 1, rightBorder);
                    rightBorder = m - 1;
                }

            }
        }

        private static int Partition(int[] array, int leftBorder, int rightBorder)
        {
            int pivotIndex = leftBorder + (rightBorder - leftBorder) / 2;

            int pivotValue = array[pivotIndex];
            array[pivotIndex] = array[leftBorder];

            int[] pivotArrayValue = jaggedArray[pivotIndex];
            jaggedArray[pivotIndex] = jaggedArray[leftBorder];

            int i = leftBorder + 1;
            int j = rightBorder;

            while (true)
            {
                if (sortDirection == SortDirection.Increasing)
                {
                    while ((i < j) && (pivotValue > array[i])) i++;
                    while ((j >= i) && (array[j]) > pivotValue) j--;
                }

                if (sortDirection == SortDirection.Decreasing)
                {
                    while ((i < j) && (pivotValue < array[i])) i++;
                    while ((j >= i) && (array[j]) < pivotValue) j--;
                }

                if (i >= j) break;
                SwapArrayRows(array, i, j);
                j--;
                i++;
            }

            array[leftBorder] = array[j];
            array[j] = pivotValue;

            jaggedArray[leftBorder] = jaggedArray[j];
            jaggedArray[j] = pivotArrayValue;

            return j;
        }

        private static void SwapArrayRows(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            int[] tempRow = jaggedArray[i];
            jaggedArray[i] = jaggedArray[j];
            jaggedArray[j] = tempRow;
        }
    }
}
