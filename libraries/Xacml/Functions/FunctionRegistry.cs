using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Functions
{
    public class FunctionRegistry : IFunctionRegistry
    {
        private IDictionary<string, Delegate> registry;

        public FunctionRegistry()
        {
            registry = new Dictionary<string, Delegate>();
        }

        public FunctionRegistry(IDictionary<string, Delegate> registry)
        {
            this.registry = registry;
        }

        public void RegisterFunction(string functionId, Delegate function)
        {
            this.registry.Add(functionId, function);
        }

        public Delegate GetFunction(string functionId)
        {
            Delegate function;
            if (registry.TryGetValue(functionId, out function))
                return function;
            throw new Exception("Function not Found");
        }
    }
}
