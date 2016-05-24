using System;
using System.Collections.Generic;

namespace Oriz
{
    public class Policy : IPolicy
    {
        public string Id { get; private set; }

        public ITarget Target { get; private set; }

        public ICombiningAlgorithm CombiningAlgorithm { get; private set; }

        public IEnumerable<IRule> Rules { get; private set; }

        public Policy(string id, 
            ITarget target, 
            ICombiningAlgorithm combiningAlgorithm, 
            IEnumerable<IRule> rules)
        {
            Id = id;
            Target = target;
            CombiningAlgorithm = combiningAlgorithm;
            Rules = rules;
        }

        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            return CombiningAlgorithm.Evaluate(Rules, authorizationContext);
        }
    }
}
