using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathHelper.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        Polynomial poly1 = new Polynomial(1, 15, 0, 45, 1, 0, 14, 3, 0);
        Polynomial poly2 = new Polynomial(32, 4, 6, 0, 47, 2, 3);

        double coefficient = 5;


        [TestMethod()]
        public void MultiplyTest()
        {
            string expected = "32*x^14 + 484*x^13 + 66*x^12 + 1530*x^11 + 259*x^10 + 981*x^9 + 487*x^8 + 2312*x^7 " +
                              "+ 233*x^6 + 155*x^5 + 661*x^4 + 169*x^3 + 48*x^2 + 9*x^1";
            var actual = poly1 * poly2;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MultiplyToNullExceptionTest()
        {
            var actual = poly1 * null;
        }

        [TestMethod()]
        public void MultiplyByZeroTest()
        {
            string expected = "0";
            var actual = poly1 * 0;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        public void MultiplyByACoefficientTest()
        {
            string expected = "5*x^8 + 75*x^7 + 225*x^5 + 5*x^4 + 70*x^2 + 15*x^1";
            var actual = poly1 * coefficient;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        public void AdditionTest()
        {
            string expected = "1*x^8 + 15*x^7 + 32*x^6 + 49*x^5 + 7*x^4 + 61*x^2 + 5*x^1 + 3";
            var actual = poly1 + poly2;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdditionWithNullExceptionTest()
        {
            var actual = poly1 + null;
        }

        [TestMethod()]
        public void SubstractTest1()
        {
            string expected = "1*x^8 + 15*x^7 - 32*x^6 + 41*x^5 - 5*x^4 - 33*x^2 + 1*x^1 - 3";
            var actual = poly1 - poly2;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        public void SubstractTest2()
        {
            string expected = "- 1*x^8 - 15*x^7 + 32*x^6 - 41*x^5 + 5*x^4 + 33*x^2 - 1*x^1 + 3";
            var actual = poly2 - poly1;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubstractWithNullExceptionTest()
        {
            var actual = poly1 - null;
        }

        [TestMethod()]
        public void DivideByACoefficientTest()
        {
            string expected = "0.2*x^8 + 3*x^7 + 9*x^5 + 0.2*x^4 + 2.8*x^2 + 0.6*x^1";
            var actual = poly1 / coefficient;
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DivideNullExceptionTest()
        {
            Polynomial poly = null;
            var actual = poly / 10;
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var actual = poly1 / 0;
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Polynomial testPoly = new Polynomial(1, 15, 0, 45, 1, 0, 14, 3, 0);
            bool expected = testPoly == poly1;
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void EqualsTest3()
        {
            Polynomial testPoly = new Polynomial(1, 15, 0, 45, 1, 0, 14, 3, 0);
            var expected = testPoly.Equals(poly1);
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void EqualsTest2()
        {
            Polynomial testPoly = poly1;
            bool expected = testPoly == poly1;
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void NotEqualsTest1()
        {
            Polynomial testPoly = poly2;
            bool expected = testPoly != poly1;
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void NotEqualsTest2()
        {
            Polynomial testPoly = new Polynomial(32, 4, 6, 0, 47, 2, 4);
            bool expected = testPoly != poly1;
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void ToFullStringTest()
        {
            string expected = "1*x^8 + 15*x^7 + 0*x^6 + 45*x^5 + 1*x^4 + 0*x^3 + 14*x^2 + 3*x^1 + 0";
            var actual = poly1.ToString("F");
            int b = String.Compare(expected, actual.ToString());
            Assert.AreEqual(b, 0);
        }
    }
}
