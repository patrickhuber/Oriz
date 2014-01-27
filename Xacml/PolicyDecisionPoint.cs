using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml
{
    public class PolicyDecisionPoint : IPolicyDecisionPoint
    {

        public PolicyDecisionPoint(IPolicyInformationPoint policyInformationPoint, IPolicyAccessPoint policyAccessPoint)
        {
            PolicyInformationPoint = policyInformationPoint;
            PolicyAccessPoint = policyAccessPoint;
        }

        public IPolicyInformationPoint PolicyInformationPoint
        {
            get;
            private set;
        }

        public IPolicyAccessPoint PolicyAccessPoint
        {
            get;
            private set;
        }

        public ResponseType Evaluate(RequestType request)
        {
            var requestAttributes = request.Attributes;
            var policies = PolicyAccessPoint.GetTargetedPolicies(requestAttributes);
            // TODO: Call PAP to get applicable policies based on the targets
            // TODO: Call PIP to get more information about the resources
            // TODO: Run the applicable policies to get an authorization decision
            throw new NotImplementedException();
        }
    }
}
