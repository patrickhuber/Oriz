using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class Policy : IDecisionEvaluator
    {
        public string Id { get; set; }

        public ICollection<Rule> Rules { get; set; }

        public Target Target { get; set; }

        public CombiningAlgorithm CombiningAlgorithm { get; set; }

        public Decision Evaluate(AuthorizationContext authorizationContext)
        {
            throw new NotImplementedException();
        }
    }
}
