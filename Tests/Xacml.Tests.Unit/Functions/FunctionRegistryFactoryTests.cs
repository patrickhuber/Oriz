using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Functions;

namespace Xacml.Tests.Unit.Functions
{
    [TestClass]
    public class FunctionRegistryFactoryTests
    {
        [TestMethod]
        public void Test_FunctionReigstryFactory_Covers_String_Methods()
        {
            IFunctionRegistryFactory functionRegistryFactory = new FunctionRegistryFactory();
        }
    }
}
