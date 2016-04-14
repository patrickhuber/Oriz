using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class PolicyDecisionPoint
    {
        public PolicyManagementPoint PolicyManagementPoint { get; private set; }

        public PolicyDecisionPoint(PolicyManagementPoint policyManagementPoint)
        {
            PolicyManagementPoint = policyManagementPoint;
        }

        public AuthorizationResponse Authorize(AuthorizationRequest request)
        {
            var policies = PolicyManagementPoint.GetApplicablePolicies(request.AuthorizationContext);
            var policySets = PolicyManagementPoint.GetApplicablePolicySets(request.AuthorizationContext);

            
            var results = new List<Result>();
            foreach (var policySet in policySets)
                results.Add(new Result { Decision = policySet.Evaluate(request.AuthorizationContext) });
            foreach (var policy in policies)
                results.Add(new Result { Decision = policy.Evaluate(request.AuthorizationContext) });

            return new AuthorizationResponse { Results = results };
        }
    }
}
