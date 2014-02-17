using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Types;

namespace Xacml.Tests.Unit.Types
{
    /// <summary>
    /// Summary description for YearMonthDurationTests
    /// </summary>
    [TestClass]
    public class YearMonthDurationTests
    {
        public YearMonthDurationTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void YearMonthDuration_Years_Returns_Year_Part()
        {
            var ymd = new YearMonthDuration(2, 6);
            Assert.AreEqual(2, ymd.Years);
            Assert.AreEqual(6, ymd.Months);
        }

        [TestMethod]
        public void YearMonthDuration_Parse_2_Years_6_Months()
        {
            var result = YearMonthDuration.Parse("P2Y6M"); // 2 years, 6 months
            Assert.AreEqual(2, result.Years);
            Assert.AreEqual(6, result.Months);
        }

        [TestMethod]
        public void YearMonthDuration_Parse_20_Months()
        { 
            var result = YearMonthDuration.Parse("P20M"); // 20 months (the number of months can be more than 12)
            Assert.AreEqual(1, result.Years);
            Assert.AreEqual(8, result.Months);
        }

        [TestMethod]
        public void YearMonthDuration_Parse_20_Months_0_Years()
        { 
            var result = YearMonthDuration.Parse("P0Y20M"); // 20 months (0 is permitted as a number, but is not required)
            Assert.AreEqual(1, result.Years);
            Assert.AreEqual(8, result.Months);            	
        }

        [TestMethod]
        public void YearMonthDuration_Parse_0_Years()
        { 
            var result = YearMonthDuration.Parse("P0Y"); // 0 years
            Assert.AreEqual(0, result.Years);
            Assert.AreEqual(0, result.Months);
        }

        [TestMethod]
        public void YearMonthDuration_Parse_Negative_60_Years()
        {
            var result = YearMonthDuration.Parse("-P60Y"); // 0 years
            Assert.AreEqual(-60, result.Years);
            Assert.AreEqual(0, result.Months);
        }
    }
}
