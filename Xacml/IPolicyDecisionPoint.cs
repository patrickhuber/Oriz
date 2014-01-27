using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml
{
    public interface IPolicyDecisionPoint
    {
        IPolicyInformationPoint PolicyInformationPoint { get; }
        IPolicyAccessPoint PolicyAccessPoint { get; }
        ResponseType Evaluate(RequestType request);
    }
}
