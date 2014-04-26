using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Lexer : ILexer
    {
        private char Null = '\0';
        private IList<TokenDefinition> _tokenDefinitions;
        
        public Lexer()
        {
            _tokenDefinitions = new List<TokenDefinition>();
        }

        public Lexer(IEnumerable<TokenDefinition> tokenDefinitions)
        {
            _tokenDefinitions = new List<TokenDefinition>(tokenDefinitions);
        }

        private IEnumerable<Token> TokenizeCore(string input)
        {
            char lookAhead = Null;
            int startIndex = 0;
            int i = 0;
            for (; i < input.Length; i++)
            {
                if (i < input.Length - 1)
                    lookAhead = input[i + 1];
                else
                    lookAhead = Null;

                var substringBuilder = new StringBuilder(input.Substring(startIndex, i - startIndex + 1));
                var matches = _tokenDefinitions
                    .Where(x => x.IsMatch(substringBuilder.ToString()))
                    .ToArray();

                if (matches.Length == 0)
                    throw new ParseException(
                        string.Format("Invalid token found at position {0}", startIndex));

                string tokenData = substringBuilder.ToString();
                substringBuilder.Append(lookAhead);

                var anyLookaheadMatches = _tokenDefinitions
                    .Any(x => x.IsMatch(substringBuilder.ToString()));

                if (!anyLookaheadMatches)
                {
                    TokenDefinition tokenDefinition = matches.First();
                    Token token = new Token
                    {
                        Type = tokenDefinition.TokenType,
                        Position = startIndex,
                        Data = tokenData
                    };
                    startIndex = i + 1;
                    yield return token;
                }
            }

            if (i != input.Length)
                throw new ParseException("Unexpected end of input reached.");

            yield break;
        }

        public LookaheadEnumerable<Token> Tokenize(string input)
        {
            return new LookaheadEnumerable<Token>(TokenizeCore(input));
        }

        public void AddTokenDefinition(TokenDefinition tokenDefinition)
        {
            this._tokenDefinitions.Add(tokenDefinition);
        }
    }
}
