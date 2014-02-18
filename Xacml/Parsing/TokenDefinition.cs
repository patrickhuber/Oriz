using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public abstract class TokenDefinition
    {
        protected TokenDefinition(string tokenType)
        {
            this.TokenType = tokenType;
        }

        public string TokenType { get; set; }
        public abstract bool IsMatch(string input);
    }
}
