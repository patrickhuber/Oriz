using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Functions
{
    public interface IFunctionRegistry
    {
        void RegisterFunction(string functionId, Delegate function);
        Delegate GetFunction(string functionId);
    }
}
