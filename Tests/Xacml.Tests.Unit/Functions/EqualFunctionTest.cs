using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xacml.Functions;
using Xacml.Types;

namespace Xacml.Tests.Unit.Functions
{
    /// <summary>
    /// Summary description for FunctionTest
    /// </summary>
    [TestClass]
    public class EqualFunctionTest
    {
        public EqualFunctionTest()
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
        public void Test_String_Equal_Returns_True()
        {
            var mockDependencyResolver = new Mock<IDependencyResolver>();
            mockDependencyResolver
                .Setup(x => x.GetService<IFunction>(It.IsAny<string>()))
                .Returns<string>(name => 
                {
                    if (name == Constants.Functions.String.Equal)
                        return new EqualFunction();
                    return null;
                });

            var dependencyResolver = mockDependencyResolver.Object;
            var functionFactory = new FunctionFactory(dependencyResolver);
            var function = functionFactory.Create(Constants.Functions.String.Equal);
            var result = function.Evaluate(
                new StringType[]
                { 
                    new StringType{ Value = "abc123" },
                    new StringType{ Value = "abc123" }
                });
        }
    }
}
