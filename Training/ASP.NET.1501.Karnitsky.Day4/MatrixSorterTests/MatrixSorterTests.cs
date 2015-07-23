using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MatrixHelper.Tests
{
    [TestClass()]
    public class MatrixSorterTests
    {

        #region Array
        private int[][] array = new int[][]
            {
                new int[]{38,-10,-19,70,41,45,98,47,-2},
                new int[]{5,81,-37,33,97,-12,32,-35},
                new int[]{},
                null,
                new int[]{-5,23,56,73,26,81,91,41,43,-1,-23,43,-48,-20},
                new int[]{89,-32,25,54,75,-11},
                new int[]{64,31,-33},
                null,
                new int[]{0,0,0,456789},
                null,
                null
            };

        #endregion

        [TestMethod()]
        public void QuickSortMaxAbsIncreasingInterfaceTest()
        {
            int[][] expected = new int[][]
            {
                null,
                null,
                null,
                null,
                array[2],
                array[6],
                array[5],
                array[4],
                array[1],
                array[0],
                array[8]
            };

            QuickSorter qs = new QuickSorter();
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            array.Sort(qs, st);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortMaxAbsIncreasingDelegateTest()
        {
            int[][] expected = new int[][]
            {
                null,
                null,
                null,
                null,
                array[2],
                array[6],
                array[5],
                array[4],
                array[1],
                array[0],
                array[8]
            };

            QuickSorter qs = new QuickSorter();
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            array.Sort(qs, ((IComparer)st).Compare);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortMaxAbsDecreasingInterfaceTest()
        {
            int[][] expected = new int[][]
            {                
                array[8],
                array[0],
                array[1],
                array[4],
                array[5],
                array[6],
                array[2],
                null,
                null,
                null,
                null 
            };

            QuickSorter qs = new QuickSorter();
            MaxAbsElementsDecreasing st = new MaxAbsElementsDecreasing();
            array.Sort(qs, st);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortMaxAbsDecreasingDelegateTest()
        {
            int[][] expected = new int[][]
            {                
                array[8],
                array[0],
                array[1],
                array[4],
                array[5],
                array[6],
                array[2],
                null,
                null,
                null,
                null 
            };

            QuickSorter qs = new QuickSorter();
            MaxAbsElementsDecreasing st = new MaxAbsElementsDecreasing();
            array.Sort(qs, ((IComparer)st).Compare);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortSumIncreasingInterfaceTest()
        {
            int[][] expected = new int[][]
            {                
                null,
                null,
                null,
                null,
                array[2],
                array[6],                
                array[1],
                array[5],
                array[0],
                array[4],
                array[8] 
            };

            QuickSorter qs = new QuickSorter();
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            array.Sort(qs, st);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortSumIncreasingDelegateTest()
        {
            int[][] expected = new int[][]
            {                
                null,
                null,
                null,
                null,
                array[2],
                array[6],                
                array[1],
                array[5],
                array[0],
                array[4],
                array[8] 
            };

            QuickSorter qs = new QuickSorter();
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            array.Sort(qs, ((IComparer)st).Compare);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortSumDecreasingInterfaceTest()
        {
            int[][] expected = new int[][]
            { 
                array[8],
                array[4],
                array[0],
                array[5],
                array[1],
                array[6], 
                array[2],
                null,
                null,
                null,
                null
            };

            QuickSorter qs = new QuickSorter();
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            array.Sort(qs, st);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortSumDecreasingDelegateTest()
        {
            int[][] expected = new int[][]
            { 
                array[8],
                array[4],
                array[0],
                array[5],
                array[1],
                array[6], 
                array[2],
                null,
                null,
                null,
                null
            };

            QuickSorter qs = new QuickSorter();
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            array.Sort(qs, ((IComparer)st).Compare);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortRowsLengthIncreasingDelegateTest()
        {
            int[][] expected = new int[][]
            { 
                null,
                null,
                null,
                null,
                array[2],
                array[6],                
                array[8],
                array[5],
                array[1],
                array[0],
                array[4]
            };

            QuickSorter qs = new QuickSorter();
            
            array.Sort(qs, Comparators.CompareRowsLengthIncreasing);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortRowsLengthDecreasingDelegateTest()
        {
            int[][] expected = new int[][]
            { 
                array[4],
                array[0],
                array[1],
                array[5],
                array[8],
                array[6], 
                array[2],
                null,
                null,
                null,
                null
            };

            QuickSorter qs = new QuickSorter();

            array.Sort(qs, Comparators.CompareRowsLengthDecreasing);
            int[][] actual = array;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionTest1()
        {   
            QuickSorter qs = null;
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            array.Sort(qs, st);  
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionTest2()
        {
            QuickSorter qs = new QuickSorter();
            ElementsSumDecreasing st = null;
            array.Sort(qs, st);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullRefferenceExceptionTest()
        {
            int[][] testArray = null;
            QuickSorter qs = new QuickSorter();
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            testArray.Sort(qs, st);
        }
    }
}
