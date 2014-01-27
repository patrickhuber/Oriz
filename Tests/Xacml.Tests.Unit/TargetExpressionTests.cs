using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Schemas;
using System.Collections.Generic;

namespace Xacml.Tests.Unit
{
    [TestClass]
    public class TargetExpressionTests
    {
        [TestMethod]
        public void Test_Evaluate_Matches_User_Is_Administrator()
        {
            const string Role = "urn:oasis:names:tc:xacml:3.0:example:attribute:role";
            TargetType targetType = new TargetType(
                new AnyOfType(
                    new AllOfType(
                        new MatchType(
                            Constants.Functions.String.OneAndOnly,
                            new AttributeValueType(
                                Constants.DataTypes.String,
                                "Administrator"),
                            new AttributeDesignatorType(
                                Constants.SubjectCategory.AccessSubject,
                                Role,
                                Constants.DataTypes.String)
                            ))));

            var allAttributes = new List<AttributesType>()
            {
                new AttributesType(Constants.SubjectCategory.AccessSubject, 
                    new AttributeType(Role, Constants.DataTypes.String, "Administrator"),
                    new AttributeType(Role, Constants.DataTypes.String, "Physician"))
            };

            var targetExpression = new TargetExpression(targetType);
            var result = targetExpression.Evaluate(allAttributes);
            Assert.IsTrue(result);
        }
    }
}
