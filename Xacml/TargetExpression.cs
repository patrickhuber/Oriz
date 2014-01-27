using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Xacml.Schemas;

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
                return EvaluateDesignatorMatch(match, match.Item as AttributeDesignatorType, attributes);
            else if (match.Item is AttributeSelectorType)
                return EvaluateSelectorMatch(match, match.Item as AttributeSelectorType, attributes);
            throw new InvalidOperationException("Unknown match item detected. Expected AttributeDesignator or AttributeSelector");
        }

        private bool EvaluateDesignatorMatch(MatchType matchType, AttributeDesignatorType designator, IEnumerable<AttributesType> attributes)
        {
            var matchingAttributes = FindMatchingAttributes(designator, attributes);
            throw new NotImplementedException();
        }

        private IEnumerable<AttributeType> FindMatchingAttributes(AttributeDesignatorType designator, IEnumerable<AttributesType> attributes)
        {
            return
                from list in attributes
                where list.Category == designator.Category
                from a in list.Attribute
                where a.AttributeId == designator.AttributeId
                select a;

            //var matches2 = attributes
            //    .Where(list => list.Category == designator.Category)
            //    .Select(list => list.Attribute.Where(a => a.AttributeId == designator.AttributeId));

            //foreach (var attributeList in attributes)
            //{
            //    bool categoryMatch = attributeList.Category == designator.Category;
            //    if (categoryMatch)
            //    {
            //        foreach (var attribute in attributeList.Attribute)
            //        {
            //            bool attributeIdMatch = attribute.AttributeId == designator.AttributeId;
            //            if (attributeIdMatch)
            //            {
            //                yield return attribute;
            //            }
            //        }
            //    }
            //}
        }

        private bool EvaluateSelectorMatch(MatchType matchType, AttributeSelectorType selectorType, IEnumerable<AttributesType> attributes)
        {
            throw new NotImplementedException();
        }
    }
}
