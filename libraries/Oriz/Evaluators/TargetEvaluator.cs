using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oriz.Schema;

namespace Oriz.Evaluators
{
    public class TargetEvaluator : ITargetEvaluator
    {
        public IMatchEvaluatorRegistry MatchEvaluatorRegistry { get; }

        public MatchResult Evaluate(Target target, AuthorizationContext context)
        {
            foreach (var anyOf in target.AnyOf)
                if (Evaluate(anyOf, context) == MatchResult.False)
                    return MatchResult.False;
            return MatchResult.True;
        }

        private MatchResult Evaluate(AnyOf anyOf, AuthorizationContext context)
        {
            foreach (var allOf in anyOf.AllOf)
                if (Evaluate(allOf, context) == MatchResult.True)
                    return MatchResult.True;
            return MatchResult.False;
        }

        private MatchResult Evaluate(AllOf allOf, AuthorizationContext context)
        {
            foreach (var match in allOf.Matches)
            {
                var matchEvaluator = MatchEvaluatorRegistry.Get(match.Id);
                if (matchEvaluator.Evaluate(match, context) == MatchResult.False)
                    return MatchResult.False;
            }
            return MatchResult.True;
        }
    }
}
