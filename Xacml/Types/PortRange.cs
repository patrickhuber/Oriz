using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Parsing;

namespace Xacml.Types
{
    public struct PortRange
    {
        public PortRange(int lowerBound, int upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public static PortRange Parse(string portRangeString)
        {
            var stateMachine = new StateMachine(0);
            stateMachine.AddRegexTransition(0, 1, Tokenizer.NumberTokenType, @"\d+");
            stateMachine.AddTransition(0, 2, Tokenizer.DashTokenType);
            stateMachine.AddRegexTransition(2, 3, Tokenizer.NumberTokenType, @"\d+");
            stateMachine.AddTransition(1, 4, Tokenizer.DashTokenType);
            stateMachine.AddRegexTransition(4, 5, Tokenizer.NumberTokenType, @"\d+");

            int lowerBound = int.MinValue;
            int upperBound = int.MaxValue;

            var tokenizer = new Tokenizer();
            foreach (var token in tokenizer.Tokenize(portRangeString))
                if (stateMachine.MoveNext(token))
                {
                    if (stateMachine.CurrentState == 1)
                        lowerBound = Int32.Parse(token.Data);
                    else if (stateMachine.CurrentState == 3)
                        upperBound = Int32.Parse(token.Data);
                    else if (stateMachine.CurrentState == 5)
                        upperBound = Int32.Parse(token.Data);
                }
                else
                {
                    if (!new int[] { 1, 3, 4, 5 }.Contains(stateMachine.CurrentState))
                        throw new Exception(
                            string.Format("Unexpected token {0} found at position {1}", token.Data, token.Position));
                    break;
                }

            return new PortRange(lowerBound, upperBound);
        }

        public int LowerBound;
        public int UpperBound;

        private class Tokenizer
        {
            public const string UnknownTokenType = "UNKNOWN";
            public const string DashTokenType = "DASH";
            public const string NumberTokenType = "NUMBER";
            
            public IEnumerable<Token> Tokenize(string input)
            {
                Token currentToken = new Token();
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    if (Char.IsNumber(c))
                    {
                        if (currentToken.Type == NumberTokenType)
                            currentToken.Data += c;
                        else
                        {
                            if (i > 0)
                                yield return currentToken;
                            currentToken = new Token(NumberTokenType, i, c.ToString());
                        }
                    }
                    else if (c == '-')
                    {
                        if (i > 0)
                            yield return currentToken;
                        currentToken = new Token(DashTokenType, i, c.ToString());
                    }
                    else
                    {
                        if (i > 0)
                            yield return currentToken;
                        currentToken = new Token(UnknownTokenType, i, c.ToString());
                    }                    
                }
                yield return currentToken;
            }
        }
    }
}
