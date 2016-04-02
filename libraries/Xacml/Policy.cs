using System;
using System.Collections.Generic;

namespace Xacml
{
    public class Policy : IDecisionEvaluator
    {
        public string Id { get; set; }

        public ICollection<Rule> Rules { get; set; }

        public Target Target { get; set; }

        public CombiningAlgorithm CombiningAlgorithm { get; set; }

        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            return CombiningAlgorithm.Evaluate(Rules, authorizationContext);
        }
    }
}
