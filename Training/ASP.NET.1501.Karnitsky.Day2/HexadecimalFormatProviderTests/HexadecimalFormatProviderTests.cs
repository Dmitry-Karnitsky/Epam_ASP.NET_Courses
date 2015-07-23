using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Custom_Format_Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Custom_Format_Provider.Tests
{
    [TestClass()]
    public class HexadecimalFormatProviderTests
    {
        HexadecimalFormatProvider fp = new HexadecimalFormatProvider(CultureInfo.GetCultureInfo("en-US"));

        [TestMethod()]
        public void Format_FromZeroIntToHexTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:hex}", 0), "0");
        }

        [TestMethod()]
        public void Format_FromPositiveIntToHexTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:hex}", 123456), "1e240");
        }

        [TestMethod()]
        public void Format_FromMaxIntToHexTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:hex}", int.MaxValue), "7fffffff");
        }

        [TestMethod()]
        public void Format_FromNegativeLongToHexTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:hex}", -1564898), "ffffffffffe81f1e");
        }

        [TestMethod()]
        public void Format_FromMinLongToHexTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:hex}", long.MinValue), "8000000000000000");
        }

        [TestMethod()]
        public void GetFormat_ICustomFormatterReturnFormatterTypeTest()
        {
            Assert.AreSame(fp, fp.GetFormat(Type.GetType("System.ICustomFormatter")));
        }

        [TestMethod()]
        public void GetFormat_NotICustomFormatterReturnNotCustomFormatterTest()
        {
            Assert.AreNotSame(fp, fp.GetFormat(Type.GetType("System.Globalization.NumberFormatInfo")));
        }

        [TestMethod()]
        public void Format_FromValueToCurrencyInUsCultureTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:C}", 123456789), "$123,456,789.00");
        }

        [TestMethod()]
        public void Format_FromValueToExponentialInUsCultureTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:E}", 123456789), "1.234568E+008");
        }

        [TestMethod()]
        public void Format_FromValueToPercentInUsCultureTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:P}", 123456789), "12,345,678,900.00 %");
        }

        [TestMethod()]
        public void Format_FromValueToBuiltInHexadecimalInUsCultureTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:X}", 123456789), "75BCD15");
        }

        [TestMethod()]
        public void Format_FromValueToGeneralInUsCultureTest()
        {
            Assert.AreEqual(String.Format(fp, "{0:G}", 123456789), "123456789");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void Format_FormatExceptionTest()
        {
            String.Format(fp, "{0:X}", decimal.MaxValue);
        }
    }
}
