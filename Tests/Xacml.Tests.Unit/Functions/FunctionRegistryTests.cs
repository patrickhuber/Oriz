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
        public void FunctionRegistry_Registers_Delegates()
        {
            var dictionary = new Dictionary<string, Delegate>();
            IFunctionRegistry functionRegistery = new FunctionRegistry(dictionary);
            functionRegistery.RegisterFunction(Constants.Functions.String.Equal, new Func<string, string, bool>((str1, str2) => str1.Equals(str2)));
            functionRegistery.RegisterFunction(Constants.Functions.Integer.Add, new Func<int, int, int>((int1, int2)=>int1 + int2));
            Assert.AreEqual(2, dictionary.Count);
        }

        [TestMethod]
        public void FunctionRegistery_Recalls_Delegate()
        {
            IFunctionRegistry functionRegistry = new FunctionRegistry();
            functionRegistry.RegisterFunction(Constants.Functions.Double.Abs, new Func<double, double>(val => Math.Abs(val)));
            var function = functionRegistry.GetFunction(Constants.Functions.Double.Abs);
            var doubleAbsFunction = function as Func<double, double>;
            
            var result = doubleAbsFunction.Invoke(103.3d);
            Assert.AreEqual(103.3d, result);
            
            result = doubleAbsFunction.Invoke(-100.2342034d);
            Assert.AreEqual(100.2342034d, result);
        }
    }
}
