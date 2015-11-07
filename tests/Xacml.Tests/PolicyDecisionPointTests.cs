using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xacml.Tests
{
    [TestClass]
    public class PolicyDecisionPointTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var policyDecisionPoint = new PolicyDecisionPoint();
            var authorizationResponse = policyDecisionPoint.Authorize(
                new AuthorizationRequest
                {
                    AuthorizationContext = new AuthorizationContext
                    {
                        AttributeCategories = new[] 
                        {
                            new AttributeCategory
                            {
                                Id = Constants.Category.AccessSubject,
                                Attributes = new [] 
                                {
                                    new Attribute
                                    {
                                        Id = Constants.Attribute.SubjectId,
                                        Values = new[]
                                        {
                                            new AttributeValue
                                            {
                                                DataType = Constants.DataType.Rfc822Name,
                                                Value = "bs@simpsons.com"
                                            }
                                        }
                                    }
                                }
                            },

                            new AttributeCategory
                            {
                                Id = Constants.Category.Resource,
                            },

                            new AttributeCategory
                            {
                                Id = Constants.Category.Action,
                            }
                        }
                    }
                });
        }
    }
}
