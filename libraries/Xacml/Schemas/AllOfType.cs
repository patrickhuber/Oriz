using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class AllOfType
    {
        public AllOfType() { }
        public AllOfType(params MatchType[] match)
        {
            Match = match;
        }
    }
}
