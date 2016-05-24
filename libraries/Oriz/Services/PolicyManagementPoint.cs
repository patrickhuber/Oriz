using Oriz.Evaluators;
using Oriz.Schema;
using System;
using System.Collections.Generic;

namespace Oriz
{
    public class PolicyManagementPoint
    {
        public IList<Policy> Policies { get; private set; }

        public IList<PolicySet> PolicySets { get; private set; }

        // TODO: investigate if this is necessary or just a implementation detail of the policy management point
        public ITargetEvaluator TargetEvaluator { get; private set; }

        public PolicyManagementPoint(ITargetEvaluator targetEvaluator, IList<Policy> policies, IList<PolicySet> policySets)
        {
            Policies = new List<Policy>(policies);
            PolicySets = new List<PolicySet>(policySets);
            TargetEvaluator = targetEvaluator;
        }

        public PolicyManagementPoint()            
        {
            Policies = new List<Policy>();
            PolicySets = new List<PolicySet>();
        }

        public ICollection<Policy> GetApplicablePolicies(AuthorizationContext authorizationContext)
        {
            var applicablePolicies = new List<Policy>();
            foreach (var policy in Policies)
                if (TargetEvaluator.Evaluate(policy.Target, authorizationContext) == MatchResult.True)
                    applicablePolicies.Add(policy);
            return applicablePolicies;
        }

        public ICollection<PolicySet> GetApplicablePolicySets(AuthorizationContext authorizationContext)
        {
            var applicablePolicySets = new List<PolicySet>();
            foreach (var policySet in PolicySets)
                if (TargetEvaluator.Evaluate(policySet.Target, authorizationContext) == MatchResult.True)
                    applicablePolicySets.Add(policySet);
            return applicablePolicySets;
        }
    }
}