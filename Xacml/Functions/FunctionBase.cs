using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Types;

namespace Xacml.Functions
{
    public abstract class FunctionBase : IFunction
    {
        public abstract FunctionResult Evaluate(IEnumerable<IType> arguments);

        protected void AssertArgumentCount(int expected, IEnumerable<IType> arguments)
        {
            int counter = 0;
            foreach (var argument in arguments)
            {
                counter += 1;
                if (counter > expected)
                    break;
            }
            if (counter != expected)
                throw new ArgumentException(
                    string.Format("Invalid number of arguments. Expected {0}", expected));
        }

        protected void AssertArgumentsHaveSameType(IEnumerable<IType> arguments)
        {
            var first = arguments.First();
            bool argumentsHaveSameType = arguments.All(x=>x.Type == first.Type);
            if (!argumentsHaveSameType)
                throw new ArgumentException("Arguments must have the same type.");
        }
    }
}
