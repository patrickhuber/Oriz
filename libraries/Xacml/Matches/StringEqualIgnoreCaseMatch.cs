using System;

namespace Xacml.Matches
{
    public class StringEqualIgnoreCaseMatch : Match
    {
        public StringEqualIgnoreCaseMatch(
            AttributeDesignator designator, 
            AttributeValue value)
            : base("urn:oasis:names:tc:xacml:3.0:function:string-equal-ignore-case", 
                  designator, 
                  value)
        { }

        protected override MatchResult Evaluate(Attribute attribute)
        {
            foreach (var value in attribute.Values)
                if (value.DataType == AttributeDesignator.DataType)
                    return (AttributeValue.Value.Equals(value.Value, StringComparison.InvariantCultureIgnoreCase))
                        ? MatchResult.True
                        : MatchResult.False;

            return MatchResult.False;
        }
    }
}
