using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriz.Schema
{
    /// <summary>
    /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc297001161"/>
    /// </summary>
    public class Rule 
    {
        public string Id { get; private set; }
        public RuleEffect Effect { get; private set; }
        public Target Target { get; private set; }

        public Rule(string id, RuleEffect effect, Target target)
        {
            Id = id;
            Effect = effect;
            Target = target;
        }
    }
}
