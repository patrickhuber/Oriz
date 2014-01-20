using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Xacml
{
    public partial class AttributeType
    {
        public AttributeType(string id, string dataType, string value)
        {
            AttributeId = id;
            AttributeValue = new AttributeValueType[]{
                new AttributeValueType
                {
                    DataType = dataType,
                    Any = new XmlNode[]
                    {
                        value.ToXmlNode() 
                    }
                }
            };
        }
    }
}
