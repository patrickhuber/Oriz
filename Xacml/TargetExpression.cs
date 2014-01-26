using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Xacml
{
    public class TargetExpression
    {
        private TargetType targetType;
        
        public TargetExpression(TargetType targetType)
        {
            this.targetType = targetType;
        }

        public bool Evaluate(IEnumerable<AttributesType> attributes)
        {
            if(MatchesAllContexts())
                return true;

            return Matches(attributes);
        }

        private bool MatchesAllContexts()
        {
            return targetType.AnyOf == null || targetType.AnyOf.Length == 0;
        }

        private bool Matches(IEnumerable<AttributesType> attributes)
        {
            return targetType.AnyOf.All(anyOf => 
            {
                return anyOf.AllOf.Any(allOf => 
                {
                    return allOf.Match.All(match => 
                    {
                        return EvaluateMatch(match, attributes);
                    });
                });
            });
        }

        private bool EvaluateMatch(MatchType match, IEnumerable<AttributesType> attributes)
        {
            if (match.Item is AttributeDesignatorType)
                return EvaluateMatch(match, match.Item as AttributeDesignatorType, attributes);
            else if (match.Item is AttributeSelectorType)
                return EvaluateMatch(match, match.Item as AttributeSelectorType, attributes);
            throw new InvalidOperationException("Unknown match item detected. Expected AttributeDesignator or AttributeSelector");
        }

        private bool EvaluateMatch(MatchType matchType, AttributeDesignatorType designator, IEnumerable<AttributesType> attributes)
        {
            var matchingAttributes = FindMatchingAttributes(designator, attributes);
            throw new NotImplementedException();
        }

        private IEnumerable<AttributeType> FindMatchingAttributes(AttributeDesignatorType designator, IEnumerable<AttributesType> attributes)
        {
            foreach (var attributeList in attributes)
            {
                bool categoryMatch = attributeList.Category == designator.Category;
                if (categoryMatch)
                {
                    foreach (var attribute in attributeList.Attribute)
                    {
                        bool attributeIdMatch = attribute.AttributeId == designator.AttributeId;
                        if (attributeIdMatch)
                        {
                            yield return attribute;
                        }
                    }
                }
            }
        }

        private bool EvaluateMatch(MatchType matchType, AttributeSelectorType selectorType, IEnumerable<AttributesType> attributes)
        {
            throw new NotImplementedException();
        }
    }
}
