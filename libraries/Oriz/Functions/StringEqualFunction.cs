using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.Functions
{
    public class StringEqualFunction
    {
        public string Id { get; private set; }

        public AttributeValue AttributeValue { get; private set; }

        public StringEqualFunction(            
            AttributeValue attributeValue)
        {
            AttributeValue = attributeValue;
            Id = "urn:oasis:names:tc:xacml:1.0:function:string-equal";
        }

        public bool Evaulate(Attribute attribute )
        {
            // perf: avoid linq to avoid lambda allocation
            foreach (var attributeValue in attribute.Values)
            {
                if (attributeValue.DataType == AttributeValue.DataType)
                    return (attributeValue.Value == AttributeValue.Value);
                return false;
            }
            return false;
        }
    }
}
