using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MathHelper.Tests
{
    [TestClass()]
    public class GCDTests
    {
        public TestContext TestContext { get; set; }

        GCD gcd = new GCD();

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg2",
            DataAccessMethod.Sequential)] 
        public void CalculateWithTwoArgumentsByEucledianMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);

            var actual = GCD.CalculateEucledian(arg1, arg2);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg3",
            DataAccessMethod.Sequential)]
        public void CalculateWithThreeArgumentsByEucledianMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);
            var arg3 = Convert.ToInt32(TestContext.DataRow["Argument3"]);

            var actual = GCD.CalculateEucledian(arg1, arg2, arg3);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg4",
            DataAccessMethod.Sequential)]
        public void CalculateWithArrayArgumentsByEucledianMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);
            var arg3 = Convert.ToInt32(TestContext.DataRow["Argument3"]);
            var arg4 = Convert.ToInt32(TestContext.DataRow["Argument4"]);

            var actual = GCD.CalculateEucledian(arg1, arg2, arg3, arg4);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg2",
            DataAccessMethod.Sequential)]
        public void CalculateWithTwoArgumentsBySteinMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);

            var actual = GCD.CalculateStein(arg1, arg2);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg3",
            DataAccessMethod.Sequential)]
        public void CalculateWithThreeArgumentsBySteinMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);
            var arg3 = Convert.ToInt32(TestContext.DataRow["Argument3"]);

            var actual = GCD.CalculateStein(arg1, arg2, arg3);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\GCDMethodsTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\GCDMethodsTests.xml",
            "TestCaseArg4",
            DataAccessMethod.Sequential)]
        public void CalculateWithArrayArgumentsBySteinMethodTest()
        {
            var arg1 = Convert.ToInt32(TestContext.DataRow["Argument1"]);
            var arg2 = Convert.ToInt32(TestContext.DataRow["Argument2"]);
            var arg3 = Convert.ToInt32(TestContext.DataRow["Argument3"]);
            var arg4 = Convert.ToInt32(TestContext.DataRow["Argument4"]);

            var actual = GCD.CalculateStein(arg1, arg2, arg3, arg4);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);
            Assert.AreEqual(expected, actual);
        }        
    }
}
