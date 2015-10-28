using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml.Matches
{
    public class StringEqualMatch 
        : Match
    {
        public StringEqualMatch() 
            : base("urn:oasis:names:tc:xacml:1.0:function:string-equal")
        {
        }

        protected override bool Evaluate(Attribute attribute)
        {
            foreach (var attributeValue in attribute.Values)
                if (attributeValue.DataType == AttributeValue.DataType)
                    return attributeValue.Value == AttributeValue.Value;
            return false;
        }
    }
}
