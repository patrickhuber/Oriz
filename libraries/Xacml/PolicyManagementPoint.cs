using System;
using System.Collections.Generic;

namespace Xacml
{
    public class PolicyManagementPoint
    {
        public IList<Policy> Policies { get; set; }

        public IList<PolicySet> PolicySets { get; set; }

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