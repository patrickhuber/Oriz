using System.Collections.Generic;

namespace Xacml
{
    public interface ICombiningAlgorithm
    {
        Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context);
    }
}