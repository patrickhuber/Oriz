using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xacml.Tests
{
    [TestClass]
    public class PolicyDecisionPointTests
    {
        [TestMethod]
        public void Test_PolicyDecisionPoint_That_Read_Medical_Record_Pulls_Policy_From_PMP()
        {
            var policyManagementPoint = new PolicyManagementPoint();
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
        }
    }
}
