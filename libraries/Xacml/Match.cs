using System.Collections.Generic;

namespace Xacml
{
    public abstract class Match
    {
        public AttributeValue AttributeValue { get; set; }
        public AttributeDesignator AttributeDesignator { get; set; }
        public string Id { get; private set; }

        protected Match(string id)
        {
            Id = id;
        }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var attributeCategory in authorizationContext.AttributeCategories)
                if (Evaluate(attributeCategory) == MatchResult.True)
                    return MatchResult.True;
            return MatchResult.False;
        }

        private MatchResult Evaluate(
            AttributeCategory attributeCategory)
        {
            if (attributeCategory.Id != AttributeDesignator.Category)
                return MatchResult.False;

            foreach (var attribute in attributeCategory.Attributes)
            {
                if (attribute.Id == AttributeDesignator.AttributeId)
                    return Evaluate(attribute);
            }

            return MatchResult.False;
        }

        protected abstract MatchResult Evaluate(Attribute attribute);
    }
}