using Oriz.Evaluators;
using Oriz.Schema;
using System;
using System.Collections.Generic;

namespace Oriz.Algorithms
{
    /// <summary>
    /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc297001241"/>
    /// </summary>
    public class DenyOverridesCombiningAlgorithm : CombiningAlgorithm
    {
        public DenyOverridesCombiningAlgorithm()
            : base("urn:oasis:names:tc:xacml:3.0:policy-combining-algorithm:deny-overrides")
        { }

        public override Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context)
        {
            var atLeastOneErrorD = false;
            var atLeastOneErrorP = false;
            var atLeastOneErrorDP = false;
            var atLeastOnePermit = false;

            foreach (var decisionEvaluator in evaluators)
            {
                var decision = decisionEvaluator.Evaluate(context);
                switch (decision)
                {
                    case Decision.Deny:
                        return Decision.Deny;

                    case Decision.Permit:
                        atLeastOnePermit = true;
                        continue;

                    case Decision.NotApplicable:
                        continue;

                    case Decision.Indeterminate | Decision.Deny:
                        atLeastOneErrorD = true;
                        continue;

                    case Decision.Indeterminate | Decision.Permit:
                        atLeastOneErrorP = true;
                        continue;

                    case Decision.Indeterminate | Decision.Permit | Decision.Deny:
                        atLeastOneErrorDP = true;
                        continue;
                }
            }

            if (atLeastOneErrorDP)
                return Decision.Indeterminate | Decision.Permit;

            if (atLeastOneErrorD && (atLeastOneErrorP || atLeastOnePermit))
                return Decision.Indeterminate | Decision.Permit | Decision.Deny;

            if (atLeastOneErrorD)
                return Decision.Indeterminate | Decision.Deny;

            if (atLeastOnePermit)
                return Decision.Permit;

            if (atLeastOneErrorP)
                return Decision.Indeterminate | Decision.Permit;

            return Decision.NotApplicable;
        }
    }
}
