using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class StatefulLexer
    {
        private ILexer _lexer;
        public StatefulLexer(ILexer lexer, string input)
        {
            _lexer = lexer;
        }        
    }
}
