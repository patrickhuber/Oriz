using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class AttributesType
    {
        public AttributesType() { }
        public AttributesType(string category, params AttributeType[] attributeType)
        {
            Category = category;
            Attribute = attributeType;
        }
    }
}
