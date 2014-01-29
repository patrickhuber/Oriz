using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Types;

namespace Xacml.Functions
{
    public abstract class FunctionBase : IFunction
    {
        public abstract FunctionResult Evaluate(IEnumerable<IType> attributes);
    }
}
