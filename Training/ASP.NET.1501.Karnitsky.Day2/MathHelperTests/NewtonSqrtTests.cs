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
    public class NewtonSqrtTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\NewtonMethodTests.xml")] 
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\NewtonMethodTests.xml",
            "TestCase",
            DataAccessMethod.Sequential)] 
        public void SqrtTest()
        {
            var number = Convert.ToDouble(TestContext.DataRow["InputNumber"]);
            var power = Convert.ToDouble(TestContext.DataRow["SpecifiedPower"]);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            NewtonSqrt.Accuracy = 1 / int.MaxValue;
            var actual = NewtonSqrt.Sqrt(number, power);
            
            // Explicit double to float, because of impossibility double types comparison.
            // Two very similar double type numbers in most cases are not equal because of very long mantissa.
            // But if we cut the end of mantissa and cast it to float range, these two mantissa would
            // consist of the same binary numbers. Another problem can be, if the exponent too big for float.
            // Assume, that after root extraction both numbers exponents can fit into float range.
            Assert.AreEqual((float)expected, (float)actual); 
        }

        [TestMethod()]
        [DeploymentItem("MathHelperTests\\NewtonMethodTests.xml")]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\NewtonMethodTests.xml",
            "TestCaseExceptions",
            DataAccessMethod.Sequential)]
        [ExpectedException(typeof(ArgumentException))]
        public void SqrtExceptionTest()
        {
            var number = Convert.ToDouble(TestContext.DataRow["InputNumber"]);
            var power = Convert.ToDouble(TestContext.DataRow["SpecifiedPower"]);
            var expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            NewtonSqrt.Accuracy = 1 / int.MaxValue;
            var actual = NewtonSqrt.Sqrt(number, power);
        }
    }
}
