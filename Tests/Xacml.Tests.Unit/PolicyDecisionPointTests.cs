using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Schemas;
using System.Xml.Serialization;
using System.IO;

namespace Xacml.Tests.Unit
{
    [TestClass]
    public class PolicyDecisionPointTests
    {
        IPolicyDecisionPoint policyDecisionPoint;
        
        [TestInitialize]
        public void Initialize()
        { 
            
        }

        [TestMethod]
        [DeploymentItem(@"Requests\AdminReadFromAdministrators.xml", "Requests")]
        public void Test_Evaluate_Admin_Can_Read_From_Administrators_Area()
        {
            var xmlSerializer = new XmlSerializer(typeof(Schemas.RequestType));
            using(var stream = File.OpenRead(@"Requests\AdminReadFromAdministrators.xml"))
            {
                var requestType = xmlSerializer.Deserialize(stream) as RequestType;
                Assert.IsNotNull(requestType);
                policyDecisionPoint.Evaluate(requestType);
            }            
        }
    }
}
