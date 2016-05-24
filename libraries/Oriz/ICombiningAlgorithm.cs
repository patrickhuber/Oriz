using System.Collections.Generic;

namespace Oriz
{
    public interface ICombiningAlgorithm
    {
        Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context);
    }
}