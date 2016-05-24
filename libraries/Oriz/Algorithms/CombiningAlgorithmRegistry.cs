using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.Algorithms
{
    public class CombiningAlgorithmRegistry
    {
        private IDictionary<string, ICombiningAlgorithm> _dictionary;

        public CombiningAlgorithmRegistry()
        {
            _dictionary = new Dictionary<string, ICombiningAlgorithm>();
        }

        public void Register(ICombiningAlgorithm combiningAlgorithm)
        {
            _dictionary[combiningAlgorithm.Id] = combiningAlgorithm;
        }

        public ICombiningAlgorithm Get(string id)
        {
            ICombiningAlgorithm combiningAlgorithm;
            if (!_dictionary.TryGetValue(id, out combiningAlgorithm))
                return null;
            return combiningAlgorithm;
        }
    }
}
