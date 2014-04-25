using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Parsing;

namespace Xacml.Tests.Unit.Parsing
{
    public class AlwaysTrueTokenDefinition : TokenDefinition
    {
        public AlwaysTrueTokenDefinition(string tokenType)
            : base(tokenType)
        { }

        public override bool IsMatch(string input)
        {
            return true;
        }
    }
}
