using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xacml.Schemas;

namespace Xacml.Tests.Unit
{
    /// <summary>
    /// Summary description for PolicyEnforcementPointTests
    /// </summary>
    [TestClass]
    public class PolicyEnforcementPointTests
    {
        public PolicyEnforcementPointTests()
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
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        private IContextHandler contextHandler;
        private IPolicyDecisionPoint policyDecisionPoint;
        private PolicyEnforcementPoint policyEnforcementPoint;

        [TestInitialize()]
        public void Initialize_PolicyEnforcementPoint() 
        {
            CreateContextHandler();
            CreatePolicyDecisionPoint();           

            policyEnforcementPoint = new PolicyEnforcementPoint(policyDecisionPoint);
        }

        private void CreateContextHandler()
        {
            var mockContextHandler = new Mock<IContextHandler>();
            mockContextHandler
                .Setup(handler => handler.GetContext())
                .Returns(() =>
                {
                    return new List<AttributesType>()
                    {

                    };
                });
            contextHandler = mockContextHandler.Object;
        }
        
        private void CreatePolicyDecisionPoint()
        {
            var mockPolicyDecisionPoint = new Mock<IPolicyDecisionPoint>();
            mockPolicyDecisionPoint
                .Setup(pdp => pdp.Evaluate(Moq.It.IsAny<RequestType>()))
                .Returns<RequestType>(req =>
                {                    
                    return new ResponseType();
                });
            policyDecisionPoint = mockPolicyDecisionPoint.Object;
        }

        [TestMethod]
        public void Test_RequestAccess_Forwards_Attributes_To_Request()
        {
            var result = policyEnforcementPoint.RequestAccess(contextHandler);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsAuthorized);
        }
    }
}
