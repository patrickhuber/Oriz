using Oriz.Evaluators;
using Oriz.Schema;
using System.Collections.Generic;

namespace Oriz
{
    public interface ICombiningAlgorithm : IEntity
    {
        Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context);
    }
}