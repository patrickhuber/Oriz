using System.Collections.Generic;

namespace Oriz.Evaluators
{
    public class MatchEvaluatorRegistry : IMatchEvaluatorRegistry
    {
        private IDictionary<string, IMatchEvaluator> _dictionary;
        public MatchEvaluatorRegistry()
        {
            _dictionary = new Dictionary<string, IMatchEvaluator>();
        }

        public IMatchEvaluator Get(string id)
        {
            IMatchEvaluator match;
            if (!_dictionary.TryGetValue(id, out match))
                return null;
            return match;
        }

        public void Register(IMatchEvaluator match)
        {
            _dictionary[match.Id] = match;
        }
    }
}
