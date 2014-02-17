using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Functions
{
    public interface IFunctionRegistryFactory
    {
        IFunctionRegistry CreateFunctionRegistry();
    }
}
