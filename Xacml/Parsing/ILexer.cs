using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    /// <summary>
    /// http://blogs.msdn.com/b/drew/archive/2009/12/31/a-simple-lexer-in-c-that-uses-regular-expressions.aspx
    /// </summary>
    public interface ILexer
    {
        IEnumerable<Token> Tokenize(string input);
        void AddTokenDefinition(TokenDefinition tokenDefinition);
    }
}
