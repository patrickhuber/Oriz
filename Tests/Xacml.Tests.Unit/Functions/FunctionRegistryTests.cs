using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Functions;

namespace Xacml.Tests.Unit.Functions
{
    [TestClass]
    public class FunctionRegistryTests
    {
        [TestInitialize]
        public void Initialize()
        { }

        [TestMethod]
        public void Test_FunctionRegistry_Registers_Delegates()
        {
            IFunctionRegistry functionRegistery = new FunctionRegistry();
            functionRegistery.RegisterFunction(Constants.Functions.String.Equal, new Func<string, string, bool>((str1, str2) => str1.Equals(str2)));
            functionRegistery.RegisterFunction(Constants.Functions.Integer.Add, new Func<int, int, int>((int1, int2)=>int1 + int2));
        }

        public void Test_FunctionRegistery_Recalls_Delegate()
        {
            IFunctionRegistry functionRegistry = new FunctionRegistry();
            functionRegistry.RegisterFunction(Constants.Functions.Double.Abs, new Func<double, double>(val => Math.Abs(val)));
            var function = functionRegistry.GetFunction(Constants.Functions.Double.Abs);
            var doubleAbsFunction = function.Value as Func<double, double>;
            var result = doubleAbsFunction.Invoke(103.3d);
            Assert.AreEqual(103, result);
        }
    }
}
