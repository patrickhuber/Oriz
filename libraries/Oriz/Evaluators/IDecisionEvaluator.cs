using Oriz.Schema;
using System.Collections.Generic;

namespace Oriz.Evaluators
{
    public interface IDecisionEvaluator
    {
        Decision Evaluate(AuthorizationContext authorizationContext);
    }
}