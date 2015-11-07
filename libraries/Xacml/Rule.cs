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

        /// <summary>
        /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc325047188">Rule evaluation</see>
        /// </summary>
        /// <param name="authorizationContext"></param>
        /// <returns></returns>
        public Decision Evaluate(AuthorizationContext authorizationContext)
        {

            throw new NotImplementedException();
        }
    }
}
