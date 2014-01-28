using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Functions
{
    public abstract class FunctionBase : IFunction
    {

        public FunctionResult Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
