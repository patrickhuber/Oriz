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
                                            Identifiers.Categories.Resource,
                                            Identifiers.Resources.TargetNamespace,
                                            Identifiers.DataTypes.AnyUri),
                                        new AttributeValue(
                                            Identifiers.DataTypes.AnyUri,
                                            ""))))),
                    combiningAlgorithmId: "",
                    rules: new Rule[] { }));
            var policyDecisionPoint = new PolicyDecisionPoint(policyManagementPoint, null);

            var authorizationResponse = policyDecisionPoint.Authorize(
                new AuthorizationRequest(
                    new AuthorizationContext(
                        new AttributeCategory(
                            Identifiers.Categories.AccessSubject,
                            new Attribute(
                                Identifiers.Attributes.SubjectId,
                                new AttributeValue(
                                    dataType: Identifiers.DataTypes.Rfc822Name,
                                    value: "bs@simpsons.com"))),
                        new AttributeCategory(
                            Identifiers.Categories.Resource,
                            new Attribute(
                                Identifiers.Attributes.ResourceId,
                                new AttributeValue(
                                    dataType: Identifiers.DataTypes.AnyUri,
                                    value: "urn:simple:medical:record:12345"))),
                        new AttributeCategory(
                            Identifiers.Categories.Action,
                            new Attribute(
                                Identifiers.Attributes.ActionId,
                                new AttributeValue(
                                    dataType: Identifiers.DataTypes.String,
                                    value: "read"))))));

            Assert.IsNotNull(authorizationResponse);
            Assert.AreEqual(1, authorizationResponse.Results.Count());
            Assert.AreEqual(authorizationResponse.Results.First().Decision, Decision.Permit);
        }
    }
}
