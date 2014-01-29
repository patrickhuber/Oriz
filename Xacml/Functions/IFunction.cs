using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Types;

namespace Xacml.Functions
{
    public interface IFunction
    {
        FunctionResult Evaluate(IEnumerable<IType> arguments);
    }
}
