using Oriz;
using Oriz.Schema;

namespace Oriz.Evaluators
{
    public class StringEqualIgnoreCaseMatch : MatchEvaluator
    {
        public StringEqualIgnoreCaseMatch()
            : base("urn:oasis:names:tc:xacml:3.0:function:string-equal-ignore-case")
        { }

        protected override MatchResult Evaluate(Match match, Attribute attribute)
        {
            foreach (var value in attribute.Values)
                if (value.DataType == match.AttributeDesignator.DataType)
                    return (match.AttributeValue.Value.Equals(value.Value, System.StringComparison.InvariantCultureIgnoreCase))
                        ? MatchResult.True
                        : MatchResult.False;

            return MatchResult.False;
        }
    }
}
