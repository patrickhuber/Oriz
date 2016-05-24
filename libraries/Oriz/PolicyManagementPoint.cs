using System;
using System.Collections.Generic;

namespace Oriz
{
    public class PolicyManagementPoint
    {
        public IList<Policy> Policies { get; private set; }

        public IList<PolicySet> PolicySets { get; private set; }

        public PolicyManagementPoint(IList<Policy> policies, IList<PolicySet> policySets)
        {
            Policies = new List<Policy>(policies);
            PolicySets = new List<PolicySet>(policySets);
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
                if (policy.Target.Evaluate(authorizationContext) == MatchResult.True)
                    applicablePolicies.Add(policy);
            return applicablePolicies;
        }

        public ICollection<PolicySet> GetApplicablePolicySets(AuthorizationContext authorizationContext)
        {
            var applicablePolicySets = new List<PolicySet>();
            foreach (var policySet in PolicySets)
                if (policySet.Target.Evaluate(authorizationContext) == MatchResult.True)
                    applicablePolicySets.Add(policySet);
            return applicablePolicySets;
        }
    }
}