using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public class PolicyEnforcementPoint : IPolicyEnforcementPoint
    {
        public PolicyEnforcementPoint(IPolicyDecisionPoint policyDecisionPoint)
        {
            PolicyDecisionPoint = policyDecisionPoint;
        }

        public AccessResponse RequestAccess(IContextHandler context)
        {
            RequestType decisionRequest = GetRequestTypeFromContextHandler(context);
            ResponseType decisionResponse = PolicyDecisionPoint.Evaluate(decisionRequest);

            bool isAuthorized = CheckResponseAuthorized(decisionResponse);

            return new AccessResponse { IsAuthorized = isAuthorized };
        }

        private static RequestType GetRequestTypeFromContextHandler(IContextHandler context)
        {
            var attributeLists = context.GetContext();
            RequestType decisionRequest = new RequestType();
            decisionRequest.Attributes = attributeLists.ToArray();
            decisionRequest.CombinedDecision = false;
            decisionRequest.ReturnPolicyIdList = false;
            return decisionRequest;
        }

        private static bool CheckResponseAuthorized(ResponseType response)        
        {
            return response.Result.Any(r => r.Decision == DecisionType.Deny);
        }

        public IPolicyDecisionPoint PolicyDecisionPoint
        {
            get;
            private set;
        }
    }
}
