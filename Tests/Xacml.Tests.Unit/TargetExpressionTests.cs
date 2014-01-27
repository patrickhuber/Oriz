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
                                Constants.Subject.Role,
                                Constants.DataTypes.String)
                            ))));

            var allAttributes = new List<AttributesType>()
            {
                new AttributesType(Constants.SubjectCategory.AccessSubject, 
                    new AttributeType(Constants.Subject.Role, Constants.DataTypes.String, "Administrator"),
                    new AttributeType(Constants.Subject.Role, Constants.DataTypes.String, "Physician")),
                new AttributesType(Constants.AttributeCategories.Resource,
                    new AttributeType(Constants.Resource.ResourceId, Constants.DataTypes.AnyUri, "http://www.google.com"))
            };

            var targetExpression = new TargetExpression(targetType);
            var result = targetExpression.Evaluate(allAttributes);
            Assert.IsTrue(result);
        }
    }
}
