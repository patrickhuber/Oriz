using Oriz.Evaluators;
using Oriz.Schema;
using System;
using System.Collections.Generic;

namespace Oriz.Algorithms
{
    /// <summary>
    /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc297001243"/>
    /// </summary>
    public class PermitOverridesCombiningAlgorithm : CombiningAlgorithm
    {
        public PermitOverridesCombiningAlgorithm() 
            : base("urn:oasis:names:tc:xacml:3.0:policy-combining-algorithm:permit-overrides") { }

        public override Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context)
        {
            var atLeastOneErrorD = false;
            var atLeastOneErrorP = false;
            var atLeastOneErrorDP = false;
            var atLeastOneDeny = false;

            foreach (var evaluator in evaluators)
            {
                var decision = evaluator.Evaluate(context);
                switch (decision)
                {
                    case Decision.Deny:
                        atLeastOneDeny = true;
                        continue;
                    case Decision.Permit:
                        return Decision.Permit;
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
                return Decision.Indeterminate | Decision.Deny | Decision.Permit;

            if (atLeastOneErrorP && (atLeastOneErrorD || atLeastOneDeny))
                return Decision.Indeterminate | Decision.Deny | Decision.Permit;
            
            if (atLeastOneErrorP)
                return Decision.Indeterminate | Decision.Permit;

            if (atLeastOneDeny)
                return Decision.Deny;

            if (atLeastOneErrorD)
                return Decision.Indeterminate | Decision.Deny;

            return Decision.NotApplicable;
        }
    }
}
