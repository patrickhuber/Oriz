using Oriz.Evaluators;
using Oriz.Schema;
using System.Collections.Generic;

namespace Oriz
{
    public abstract class CombiningAlgorithm : ICombiningAlgorithm
    {
        public string Id { get; private set; }
        protected CombiningAlgorithm(string id)
        {
            Id = id;
        }

        public abstract Decision Evaluate(IEnumerable<IDecisionEvaluator> evaluators, AuthorizationContext context);
    }
}
