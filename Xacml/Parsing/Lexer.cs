using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Lexer : ILexer
    {
        private char Null = '\0';
        private IList<TokenDefinition> tokenDefinitions;
        
        public Lexer()
        {
            tokenDefinitions = new List<TokenDefinition>();
        }

        public IEnumerable<Token> Tokenize(string input)
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
                var matches = tokenDefinitions
                    .Where(x => x.IsMatch(substringBuilder.ToString()))
                    .ToArray();

                if (matches.Length == 0)
                    throw new Exception(
                        string.Format("Invalid token found at position {0}", startIndex));

                substringBuilder.Append(lookAhead);
                
                var anyLookaheadMatches = tokenDefinitions                    
                    .Any(x => x.IsMatch(substringBuilder.ToString()));
                
                if (!anyLookaheadMatches)
                { 
                    TokenDefinition tokenDefinition = matches.First();
                    Token token = new Token 
                    { 
                        Type = tokenDefinition.TokenType, 
                        Position = startIndex, 
                        Data = substringBuilder.ToString() 
                    };
                    startIndex = i + 1;
                    yield return token;
                }
            }
            
            if(i != input.Length)
                throw new Exception("Unexpected end of input reached.");

            yield break;
        }

        public void AddTokenDefinition(TokenDefinition tokenDefinition)
        {
            this.tokenDefinitions.Add(tokenDefinition);
        }
    }
}
