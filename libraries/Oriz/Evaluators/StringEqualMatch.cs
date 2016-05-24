using Oriz.Schema;

namespace Oriz.Evaluators
{
    public class StringEqualMatch 
        : MatchEvaluator
    {
        public StringEqualMatch() 
            : base("urn:oasis:names:tc:xacml:1.0:function:string-equal")
        {
        }

        protected override MatchResult Evaluate(Match match, Attribute attribute)
        {
            foreach (var attributeValue in attribute.Values)
                if (attributeValue.DataType == match.AttributeValue.DataType)
                    return (attributeValue.Value == match.AttributeValue.Value)
                        ? MatchResult.True
                        : MatchResult.False;

            return MatchResult.False;
        }
    }
}
