using Oriz.Schema;
using System.Collections.Generic;

namespace Oriz.Evaluators
{
    public abstract class MatchEvaluator : IMatchEvaluator
    {
        public string Id { get; private set; }
        protected MatchEvaluator(string id)
        {
            Id = id;
        }

        public MatchResult Evaluate(Match match, AuthorizationContext authorizationContext)
        {
            foreach (var attributeCategory in authorizationContext.AttributeCategories)
                if (Evaluate(match, attributeCategory) == MatchResult.True)
                    return MatchResult.True;
            return MatchResult.False;
        }

        private MatchResult Evaluate(
            Match match,
            AttributeCategory attributeCategory)
        {
            if (attributeCategory.Id != match.AttributeDesignator.Category)
                return MatchResult.False;

            foreach (var attribute in attributeCategory.Attributes)
            {
                if (attribute.Id == match.AttributeDesignator.AttributeId)
                    return Evaluate(match, attribute);
            }

            return MatchResult.False;
        }

        protected abstract MatchResult Evaluate(Match match, Attribute attribute);
    }
}