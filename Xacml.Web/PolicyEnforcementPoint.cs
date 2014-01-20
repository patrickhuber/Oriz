using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Web
{
    public class PolicyEnforcementPoint : IPolicyEnforcementPoint
    {
        public AccessResponse RequestAccess(IContextHandler context)
        {
            return new AccessResponse {  IsAuthorized = false };
        }
    }
}
