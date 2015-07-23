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
    public class CustomComparatorsTests
    {
        [TestMethod()]
        public void ElementsSumIncreasingBothArraysNullTest()
        {
            int[] arr1 = null;
            int[] arr2 = null;
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void ElementsSumIncreasingFirstArrayNullTest()
        {
            int[] arr1 = null;
            int[] arr2 = new int[]{1,2,3};
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingSecondArrayNullTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = null;            
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingBothArraysEmptyTest()
        {
            int[] arr1 = new int[] {};
            int[] arr2 = new int[] {};
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void ElementsSumIncreasingFirstArrayEmptyTest()
        {
            int[] arr1 = new int[] { };
            int[] arr2 = new int[] {1,2,3};
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingSecondArrayEmptyTest()
        {
            int[] arr1 = new int[] {1,2,3};
            int[] arr2 = new int[] { };
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingFirstArraySumLowerTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 4,5,6};
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingSecondArraySumLowerTest()
        {
            int[] arr1 = new int[] { 4,5,6 };
            int[] arr2 = new int[] { 1,2,3 };
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void ElementsSumIncreasingBothArraysSumEqualTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 1,2,3 };
            ElementsSumIncreasing st = new ElementsSumIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }
        
        [TestMethod()]
        public void ElementsSumDecreasingFirstArraySumLowerTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 4, 5, 6 };
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void ElementsSumDecreasingSecondArraySumLowerTest()
        {
            int[] arr1 = new int[] { 4, 5, 6 };
            int[] arr2 = new int[] { 1, 2, 3 };
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void ElementsSumDecreasingBothArraysSumEqualTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 1, 2, 3 };
            ElementsSumDecreasing st = new ElementsSumDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingBothArraysNullTest()
        {
            int[] arr1 = null;
            int[] arr2 = null;
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingFirstArrayNullTest()
        {
            int[] arr1 = null;
            int[] arr2 = new int[] { 1, 2, 3 };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingSecondArrayNullTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = null;
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingBothArraysEmptyTest()
        {
            int[] arr1 = new int[] { };
            int[] arr2 = new int[] { };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingFirstArrayEmptyTest()
        {
            int[] arr1 = new int[] { };
            int[] arr2 = new int[] { 1, 2, 3 };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingSecondArrayEmptyTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingFirstArrayAbsLowerTest()
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 4, 5, 6 };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingSecondArrayAbsLowerTest()
        {
            int[] arr1 = new int[] { 4, 5, 6, -20 };
            int[] arr2 = new int[] { 1, 2, 3, -10 };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void MaxAbsElementsIncreasingBothArraysAbsEqualTest()
        {
            int[] arr1 = new int[] { 1, 2, 3, -50 };
            int[] arr2 = new int[] { 1, 2, 3, 50 };
            MaxAbsElementsIncreasing st = new MaxAbsElementsIncreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod()]
        public void MaxAbsElementsDecreasingFirstArrayAbsLowerTest()
        {
            int[] arr1 = new int[] { 1, 2, 3, -4 , -48 };
            int[] arr2 = new int[] { 4, 5, 6, -20, 49, -30 };
            MaxAbsElementsDecreasing st = new MaxAbsElementsDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 1);
        }

        [TestMethod()]
        public void MaxAbsElementsDecreasingSecondArrayAbsLowerTest()
        {
            int[] arr1 = new int[] { 4, 5, 6 , 10, 20};
            int[] arr2 = new int[] { 1, 2, 3, -19 };
            MaxAbsElementsDecreasing st = new MaxAbsElementsDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, -1);
        }

        [TestMethod()]
        public void MaxAbsElementsDecreasingBothArraysAbsEqualTest()
        {
            int[] arr1 = new int[] { -1, 2, 3, 4, 8, -9, 18 };
            int[] arr2 = new int[] { 1, 2, 3, -9, -18 };
            MaxAbsElementsDecreasing st = new MaxAbsElementsDecreasing();
            int expected = ((IComparer)st).Compare(arr1, arr2);

            Assert.AreEqual(expected, 0);
        }

    }
}
