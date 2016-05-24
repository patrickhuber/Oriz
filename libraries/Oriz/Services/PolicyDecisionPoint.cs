using Oriz.Evaluators;
using System.Collections.Generic;

namespace Oriz.Services
{
    public class PolicyDecisionPoint
    {
        public PolicyManagementPoint PolicyManagementPoint { get; private set; }
        public IPolicyEvaluator PolicyEvaluator { get; private set; }

        public PolicyDecisionPoint(PolicyManagementPoint policyManagementPoint, IPolicyEvaluator policyEvaluator)
        {
            PolicyManagementPoint = policyManagementPoint;
            PolicyEvaluator = policyEvaluator;
        }

        public AuthorizationResponse Authorize(AuthorizationRequest request)
        {
            var policies = PolicyManagementPoint.GetApplicablePolicies(request.AuthorizationContext);
            var policySets = PolicyManagementPoint.GetApplicablePolicySets(request.AuthorizationContext);
            
            var results = new List<Result>();
            foreach (var policySet in policySets)
                results.Add(new Result { Decision = PolicyEvaluator.Evaluate(policySet, request.AuthorizationContext) });
            foreach (var policy in policies)
                results.Add(new Result { Decision = PolicyEvaluator.Evaluate(policy, request.AuthorizationContext) });

            return new AuthorizationResponse { Results = results };
        }
    }
}
