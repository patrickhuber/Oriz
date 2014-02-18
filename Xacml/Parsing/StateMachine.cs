using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Xacml.Parsing
{
    public class StateMachine
    {
        public int CurrentState { get; private set; }
        private List<int> endStates;
        private Dictionary<int, List<Transition>> states;
        
        public StateMachine(int startState)
        {
            CurrentState = startState;
            endStates = new List<int>();
            states = new Dictionary<int, List<Transition>>();
        }

        private class Transition
        {
            public string TokenType { get; set; }
            
            public int EndState { get; set; }

            public virtual bool IsMatch(Token token)
            {
                return TokenType == token.Type;
            }
        }

        private class LiteralTransition : Transition
        {
            public string Value { get; set; }

            public override bool IsMatch(Token token)
            {
                if(!base.IsMatch(token))
                    return false;
                return token.Data == Value;
            }
        }

        private class RegexTransition : Transition
        {
            public string Pattern { get; set; }
            public override bool IsMatch(Token token)
            {
                if (!base.IsMatch(token))
                    return false;
                return Regex.IsMatch(token.Data, Pattern);
            }
        }

        public void AddLiteralTransition(int start, int end, string tokenType, string value)
        {
            AddTransition(start, new LiteralTransition { EndState = end, TokenType = tokenType, Value = value});
        }

        public void AddRegexTransition(int start, int end, string tokenType, string pattern)
        {
            AddTransition(start, new RegexTransition { EndState = end, TokenType = tokenType, Pattern = pattern });
        }

        public void AddTransition(int start, int end, string tokenType)
        {
            AddTransition(start, new Transition { EndState = end, TokenType = tokenType });
        }

        private void AddTransition(int start, Transition transition)
        {
            if (!states.ContainsKey(start))
                states.Add(start, new List<Transition>());
            states[start].Add(transition);
        }

        public bool MoveNext(Token token)
        {
            List<Transition> transitions;
            if (!states.TryGetValue(CurrentState, out transitions))
                return false;
            foreach (var transition in transitions)
            {
                if (transition.IsMatch(token))
                {
                    CurrentState = transition.EndState;
                    return true;
                }
            }
            return false;
        }
    }
}
