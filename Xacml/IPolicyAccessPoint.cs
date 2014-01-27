using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml
{
    public interface IPolicyAccessPoint
    {
        IEnumerable<PolicyType> GetTargetedPolicies(IEnumerable<AttributesType> attributes);
    }
}
