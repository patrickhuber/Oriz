using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class TokenSyntaxNode : SyntaxNode
    {
        public Token Token {get;private set;}
                
        public TokenSyntaxNode(Token token)
        {
            Token = token;
        }
    }
}
