using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public abstract class CombiningAlgorithm : ICombiningAlgorithm
    {
        public abstract Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context);
    }
}
