using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml
{
    public interface IPolicyEnforcementPoint
    {
        IContextHandler ContextHandler { get; }
        AccessResponse RequestAccess(AccessRequest request);
    }
}
