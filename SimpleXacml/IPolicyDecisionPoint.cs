using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml
{
    public interface IPolicyDecisionPoint
    {
        IPolicyInformationPoint PolicyInformationPoint { get; }
        IPolicyAccessPoint PolicyAccessPoint { get; }
        ResponseType Evaluate(RequestType request);
    }
}
