using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Xacml.Parsing
{
    public class RegexTokenDefinition : TokenDefinition
    {
        private Regex regex;
        
        public RegexTokenDefinition(string tokenType, string pattern)
            : base(tokenType)
        {
            regex = new Regex(pattern);
        }

        public override bool IsMatch(string input)
        {
            return regex.IsMatch(input);
        }
    }
}
