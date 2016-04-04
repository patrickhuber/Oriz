using System.Collections.Generic;

namespace Xacml
{
    public interface IPolicy : IDecisionEvaluator
    {
        string Id { get; }

        IEnumerable<IRule> Rules { get; }

        ITarget Target { get; }

        ICombiningAlgorithm CombiningAlgorithm { get; }
    }
}