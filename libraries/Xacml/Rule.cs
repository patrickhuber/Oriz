using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    /// <summary>
    /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc297001161"/>
    /// </summary>
    public class Rule : IRule
    {
        public string Id { get; private set; }
        public RuleEffect Effect { get; private set; }
        public Target Target { get; private set; }

        public Rule(string id, RuleEffect effect, Target target)
        {
            Id = id;
            Effect = effect;
            Target = target;
        }

        /// <summary>
        /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc325047188">Rule evaluation</see>
        /// </summary>
        /// <param name="authorizationContext"></param>
        /// <returns></returns>
        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            // not using conditions right now, so the rule table will always be
            // true for the condition column
            var matchResult = Target != null 
                ? Target.Evaluate(authorizationContext) 
                : MatchResult.True;

            switch (matchResult)
            {
                case MatchResult.True:
                    if (Effect == RuleEffect.Permit)
                        return Decision.Permit;
                    return Decision.Deny;

                case MatchResult.False:
                    return Decision.NotApplicable;

                case MatchResult.Indeterminate:
                    if (Effect == RuleEffect.Permit)
                        return Decision.Indeterminate | Decision.Permit;
                    return Decision.Indeterminate | Decision.Deny;                
            }
            throw new Exception("Invalid match result detected.");
        }
    }
}
