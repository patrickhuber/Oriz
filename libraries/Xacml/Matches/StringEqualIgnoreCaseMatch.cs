using System;

namespace Xacml.Matches
{
    public class StringEqualIgnoreCaseMatch : Match
    {
        public StringEqualIgnoreCaseMatch()
            : base("urn:oasis:names:tc:xacml:3.0:function:string-equal-ignore-case")
        { }

        protected override bool Evaluate(Attribute attribute)
        {
            foreach (var value in attribute.Values)
                if (value.DataType == AttributeDesignator.DataType)
                    return AttributeValue.Value.Equals(value.Value, StringComparison.InvariantCultureIgnoreCase);

            return false;
        }
    }
}
