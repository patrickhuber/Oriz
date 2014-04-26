using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Types;

namespace Xacml.Tests.Unit.Types
{
    /// <summary>
    /// Summary description for PortRangeTests
    /// </summary>
    [TestClass]
    public class PortRangeTests
    {
        public PortRangeTests()
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
        public void Test_PortRange_Parse_LowerBound()
        {
            int lowerBound = 5000;
            string portRangeString = "5000-";
            PortRange portRange = PortRange.Parse(portRangeString);
            Assert.AreEqual(lowerBound, portRange.LowerBound);
            Assert.AreEqual(Int32.MaxValue, portRange.UpperBound);
        }

        [TestMethod]
        public void Test_PortRange_Parse_UpperBound()
        {
            int upperBound = 8000;
            string portRangeString = "-8000";
            PortRange portRange = PortRange.Parse(portRangeString);            
            Assert.AreEqual(Int32.MinValue, portRange.LowerBound);
            Assert.AreEqual(upperBound, portRange.UpperBound);
        }

        [TestMethod]
        public void Test_PortRange_Parse_Range()
        {
            int upperBound = 1000;
            int lowerBound = 5;
            string portRangeString = "5-1000";
            PortRange portRange = PortRange.Parse(portRangeString);
            Assert.AreEqual(lowerBound, portRange.LowerBound);
            Assert.AreEqual(upperBound, portRange.UpperBound);
        }
    }
}
