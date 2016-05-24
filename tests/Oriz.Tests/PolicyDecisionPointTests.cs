using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Oriz.Algorithms;
using Oriz.Schema;
using Oriz.Services;

namespace Oriz.Tests
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
                    id: "urn:oasis:names:tc:xacml:3.0:example:policyid:1",
                    target: new Target(
                        new AnyOf(
                                new AllOf(
                                    new Match(
                                        "",
                                        new AttributeDesignator(
                                            Categories.Resource, 
                                            Resource.TargetNamespace,
                                            DataType.AnyUri),
                                        new AttributeValue(
                                            DataType.AnyUri,
                                            ""))))),
                    combiningAlgorithmId: "",
                    rules: new Rule[] { }));
            var policyDecisionPoint = new PolicyDecisionPoint(policyManagementPoint, null);

            var authorizationResponse = policyDecisionPoint.Authorize(
                new AuthorizationRequest(
                    new AuthorizationContext(
                        new AttributeCategory(
                            Categories.AccessSubject,
                            new Attribute(
                                Attributes.SubjectId,
                                new AttributeValue(
                                    dataType: DataType.Rfc822Name,
                                    value: "bs@simpsons.com"))),
                        new AttributeCategory(
                            Categories.Resource,
                            new Attribute(
                                Attributes.ResourceId,
                                new AttributeValue(
                                    dataType: DataType.AnyUri,
                                    value: "urn:simple:medical:record:12345"))),
                        new AttributeCategory(
                            Categories.Action,
                            new Attribute(
                                Attributes.ActionId,
                                new AttributeValue(
                                    dataType: DataType.String,
                                    value: "read"))))));

            Assert.IsNotNull(authorizationResponse);
            Assert.AreEqual(1, authorizationResponse.Results.Count());
            Assert.AreEqual(authorizationResponse.Results.First().Decision, Decision.Permit);
        }
    }
}
