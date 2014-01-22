using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public interface IPolicyEnforcementPoint
    {
        IPolicyDecisionPoint PolicyDecisionPoint { get; }
        AccessResponse RequestAccess(IContextHandler handler);
    }
}
