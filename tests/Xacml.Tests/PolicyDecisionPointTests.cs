using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Xacml.Algorithms;
using Xacml.Matches;

namespace Xacml.Tests
{
    [TestClass]
    public class PolicyDecisionPointTests
    {
        [TestMethod]
        public void PolicyDecisionPointShouldAllowReadForAllMedicalRecords()
        {
            var policyManagementPoint = new PolicyManagementPoint();
            policyManagementPoint.Policies.Add(
                new Policy(
                    id: "urn:com.company.policies.can-read-own-medical-records",
                    target: new Target(
                        new AnyOf(
                                new AllOf(
                                    new StringEqualMatch(
                                        new AttributeDesignator(),
                                        new AttributeValue())))),
                    combiningAlgorithm: new DenyOverridesCombiningAlgorithm(),
                    rules: new IRule[] { }));
            var policyDecisionPoint = new PolicyDecisionPoint(policyManagementPoint);

            var authorizationResponse = policyDecisionPoint.Authorize(
                new AuthorizationRequest(
                    new AuthorizationContext(
                        new AttributeCategory(
                            Constants.Category.AccessSubject,
                            new Attribute(
                                Constants.Attribute.SubjectId,
                                new AttributeValue(
                                    dataType: Constants.DataType.Rfc822Name,
                                    value: "bs@simpsons.com"))),
                        new AttributeCategory(
                            Constants.Category.Resource,
                            new Attribute(
                                Constants.Attribute.ResourceId,
                                new AttributeValue(
                                    dataType: Constants.DataType.AnyUri,
                                    value: "urn:simple:medical:record:12345"))),
                        new AttributeCategory(
                            Constants.Category.Action,
                            new Attribute(
                                Constants.Attribute.ActionId,
                                new AttributeValue(
                                    dataType: Constants.DataType.String,
                                    value: "read"))))));

            Assert.IsNotNull(authorizationResponse);
            Assert.AreEqual(1, authorizationResponse.Results.Count());
            Assert.AreEqual(authorizationResponse.Results.First().Decision, Decision.Permit);
        }
    }
}
