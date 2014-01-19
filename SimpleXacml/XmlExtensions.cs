using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SimpleXacml
{
    public static class XmlExtensions
    {
        public static XmlNode ToXmlNode(this string value)
        {            
            var document = new XmlDocument();
            return document.CreateTextNode(value);            
        }
    }
}
