using System;
using System.Collections.Generic;

namespace Oriz.Schema
{
    public class Policy
    {
        public string Id { get; private set; }

        public Target Target { get; private set; }

        public string CombiningAlgorithmId { get; private set; }

        public IEnumerable<Rule> Rules { get; private set; }

        public Policy(string id, 
            Target target, 
            string combiningAlgorithmId,
            IEnumerable<Rule> rules)
        {
            Id = id;
            Target = target;
            CombiningAlgorithmId = combiningAlgorithmId;
            Rules = rules;
        }
    }
}
