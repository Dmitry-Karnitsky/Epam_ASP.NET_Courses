using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchHelper.Tests
{
    [TestClass()]
    public class BinarySearchHelperTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void BinarySearchNullReferenceExceptionTest()
        {
            int[] array = null;
            array.CustomBinarySearch<int>(3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchArgumentNullExceptionTest()
        {
            int[] array = new int[] { 1,2,3,4,5,6};
            array.CustomBinarySearch<int>(3, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchArgumentExceptionFromArrayTest()
        {
            int[] array = new int[] { };
            array.CustomBinarySearch<int>(3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchArgumentExceptionFromComparerTest()
        {
            int[] array = new int[] { };
            array.CustomBinarySearch<int>(3, ExceptionComparer);
        }

        [TestMethod()]
        public void BinarySearchElementExistsInTheMiddleTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            int expected = 2;
            int actual = array.CustomBinarySearch<int>(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchElementExistsInTheStartTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            int expected = 0;
            int actual = array.CustomBinarySearch<int>(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchElementExistsInTheEndTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            int expected = 5;
            int actual = array.CustomBinarySearch<int>(6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BinarySearchElementDoNotExistTest()
        {
            int[] array = new int[] { 1, 2, 3, 5, 6 };
            int expected = 3;
            int actual = ~array.CustomBinarySearch<int>(4);
            Assert.AreEqual(expected, actual);
        }        

        internal static int ExceptionComparer(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
