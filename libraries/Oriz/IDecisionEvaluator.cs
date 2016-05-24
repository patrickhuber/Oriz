using System.Collections.Generic;

namespace Oriz
{
    public interface IDecisionEvaluator
    {
        Decision Evaluate(AuthorizationContext authorizationContext);
    }
}