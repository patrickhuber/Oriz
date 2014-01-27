using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Xacml.Schemas
{
    public partial class AttributeType
    {
        public AttributeType(string id, string dataType, string value)
        {
            AttributeId = id;
            AttributeValue = new AttributeValueType[]
            {
                new AttributeValueType(dataType, value)
            };
        }
    }
}
