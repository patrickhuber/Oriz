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
            const string NumberTokenType = "NUMBER";
            const string DashTokenType = "DASH";

            ILexer lexer = new Lexer();
            lexer.AddTokenDefinition(new RegexTokenDefinition(NumberTokenType, @"\d+"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(DashTokenType, "[-]"));

            var stateMachine = new StateMachine(0);
            stateMachine.AddTransition(0, 1, NumberTokenType);
            stateMachine.AddTransition(0, 2, DashTokenType);
            stateMachine.AddTransition(2, 3, NumberTokenType);
            stateMachine.AddTransition(1, 4, DashTokenType);
            stateMachine.AddTransition(4, 5, NumberTokenType);

            int lowerBound = int.MinValue;
            int upperBound = int.MaxValue;                      
            
            foreach (var token in lexer.Tokenize(portRangeString))
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

        public readonly int LowerBound;
        public readonly int UpperBound;        
    }
}
