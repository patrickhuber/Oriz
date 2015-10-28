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
            throw new NotImplementedException();
        }
    }
}