using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class Rule : IDecisionEvaluator
    {
        public string Id { get; set; }
        RuleEffect Effect { get; set; }
        Target Target { get; set; }

        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            throw new NotImplementedException();
        }
    }
}
