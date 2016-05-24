using System.Collections.Generic;

namespace Oriz
{
    public interface IPolicy : IDecisionEvaluator
    {
        string Id { get; }

        IEnumerable<IRule> Rules { get; }

        ITarget Target { get; }

        ICombiningAlgorithm CombiningAlgorithm { get; }
    }
}