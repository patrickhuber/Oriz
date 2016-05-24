namespace Oriz.Matches
{
    public class StringEqualMatch 
        : Match
    {
        public StringEqualMatch(AttributeDesignator designator, AttributeValue value) 
            : base("urn:oasis:names:tc:xacml:1.0:function:string-equal", 
                  designator, value)
        {
        }

        protected override MatchResult Evaluate(Attribute attribute)
        {
            foreach (var attributeValue in attribute.Values)
                if (attributeValue.DataType == AttributeValue.DataType)
                    return (attributeValue.Value == AttributeValue.Value)
                        ? MatchResult.True
                        : MatchResult.False;

            return MatchResult.False;
        }
    }
}
