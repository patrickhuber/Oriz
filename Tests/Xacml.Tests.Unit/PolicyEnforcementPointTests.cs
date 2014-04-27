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
        private IPolicyEnforcementPoint policyEnforcementPoint;

        [TestInitialize()]
        public void Initialize_PolicyEnforcementPoint()
        {
            CreateContextHandler();            
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

        private IPolicyEnforcementPoint CreatePermitAllPolicyEnforcementPoint()
        {
            policyDecisionPoint = CreatePermitAllPolicyDecisionPoint();
            return new PolicyEnforcementPoint(policyDecisionPoint);
        }

        private IPolicyEnforcementPoint CreateDenyAllPolicyEnforcementPoint()
        {
            policyDecisionPoint = CreateDenyAllPolicyDecisionPoint();
            return new PolicyEnforcementPoint(policyDecisionPoint);
        }

        private IPolicyDecisionPoint CreatePermitAllPolicyDecisionPoint()
        {
            return CreatePolicyDecisionPoint(DecisionType.Permit);
        }

        private IPolicyDecisionPoint CreateDenyAllPolicyDecisionPoint()
        {
            return CreatePolicyDecisionPoint(DecisionType.Deny);
        }

        private IPolicyDecisionPoint CreatePolicyDecisionPoint(DecisionType decisionType)
        {
            var mockPolicyDecisionPoint = new Mock<IPolicyDecisionPoint>();
            mockPolicyDecisionPoint
                .Setup(pdp => pdp.Evaluate(Moq.It.IsAny<RequestType>()))
                .Returns<RequestType>(req =>
                {
                    return new ResponseType()
                    {
                        Result = new[]
                        {
                            new ResultType() 
                            {
                                Decision = decisionType
                            }
                        }
                    };
                });
            return mockPolicyDecisionPoint.Object;
        }

        [TestMethod]
        public void Test_RequestAccess_With_Permit_Forwards_Attributes_To_Request()
        {
            policyEnforcementPoint = CreatePermitAllPolicyEnforcementPoint();
            var result = policyEnforcementPoint.RequestAccess(contextHandler);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsAuthorized);
        }

        [TestMethod]
        public void Test_RequestAccess_With_Deny_Forwards_Attributes_To_Request()
        {
            policyEnforcementPoint = CreateDenyAllPolicyEnforcementPoint();
            var result = policyEnforcementPoint.RequestAccess(contextHandler);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsAuthorized);
        }
    }
}
