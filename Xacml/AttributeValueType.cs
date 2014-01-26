using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Xacml
{
    public partial class AttributeValueType
    {        
        public AttributeValueType(string dataType, string value)
        {
            DataType = dataType;
            Any = new XmlNode[]
            {
                value.ToXmlNode() 
            };            
        }

        public string GetStringValue()
        {
            if (Any == null || Any.Length == 0)
                return null;
            var textNode = Any.First() as XmlText;
            return textNode.Value;
        }
    }
}
