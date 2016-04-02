using System;
using System.Collections.Generic;

namespace Xacml
{
    public class PolicySet : IDecisionEvaluator
    {
        public Target Target { get; set; }

        public ICollection<PolicySet> PolicySets { get; set; }

        public ICollection<Policy> Policies { get; set; }

        public CombiningAlgorithm CombiningAlgorithm { get; set; }

        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            return CombiningAlgorithm.Evaluate(GetEvaluators(), authorizationContext);
        }

        private IEnumerable<IDecisionEvaluator> GetEvaluators()
        {
            foreach (var policy in Policies)
                yield return policy;

            foreach (var policySet in PolicySets)
                yield return policySet;
        }
    }
}