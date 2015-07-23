using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FibonacciNumbersCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FibonacciNumbersCalculation.Tests
{
    [TestClass()]
    public class FibonacciNumbersTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindLessThanZeroNumbersTest()
        {
            FibonacciNumbers.Find(-1);
        }

        [TestMethod()]
        public void FindZeroNumbersTest()
        {
            CollectionAssert.AreEquivalent((ICollection)new long[0], (ICollection)FibonacciNumbers.Find(0));
        }

        [TestMethod()]
        public void FindFirstTenNumbersTest()
        {
            long[] expected = new long[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            List<long> actual = new List<long>();

            foreach(long number in FibonacciNumbers.Find(10))
            {
                actual.Add(number);
            }
            CollectionAssert.AreEquivalent(expected, actual);
        }

    }
}
