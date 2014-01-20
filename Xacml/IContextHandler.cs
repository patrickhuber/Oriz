using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public interface IContextHandler
    {
        IEnumerable<AttributesType> GetContext();
    }
}
