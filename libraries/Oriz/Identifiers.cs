using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz
{
    public static class Identifiers
    {
        public static class Attributes
        {
            public static readonly string SubjectId = "urn:oasis:names:tc:xacml:1.0:subject:subject-id";
            public static readonly string ResourceId = "urn:oasis:names:tc:xacml:1.0:resource:resource-id";
            public static readonly string ActionId = "urn:oasis:names:tc:xacml:1.0:action:action-id";
        }

        public static class Categories
        {
            public static readonly string AccessSubject = "urn:oasis:names:tc:xacml:1.0:subject-category:access-subject";
            public static readonly string Resource = "urn:oasis:names:tc:xacml:3.0:attribute-category:resource";
            public static readonly string Action = "urn:oasis:names:tc:xacml:3.0:attribute-category:action";
        }

        public static class DataTypes
        {
            public static readonly string Rfc822Name = "urn:oasis:names:tc:xacml:1.0:data-type:rfc822Name";
            public static readonly string AnyUri = "http://www.w3.org/2001/XMLSchema#anyURI";
            public static readonly string String = "http://www.w3.org/2001/XMLSchema#string";
            public static readonly string Boolean = "http://www.w3.org/2001/XMLSchema#boolean";
            public static readonly string Integer = "http://www.w3.org/2001/XMLSchema#integer";
            public static readonly string Double = "http://www.w3.org/2001/XMLSchema#double";
            public static readonly string Time = "http://www.w3.org/2001/XMLSchema#time";
            public static readonly string Date = "http://www.w3.org/2001/XMLSchema#date";
            public static readonly string DateTime = "http://www.w3.org/2001/XMLSchema#dateTime";
            public static readonly string DayTimeDuration = "http://www.w3.org/2001/XMLSchema#dayTimeDuration";
            public static readonly string YearMonthDuration = "http://www.w3.org/2001/XMLSchema#yearMonthDuration";
            public static readonly string HexBinary = "http://www.w3.org/2001/XMLSchema#hexBinary";
            public static readonly string Base64Binary = "http://www.w3.org/2001/XMLSchema#base64Binary";
            public static readonly string X500Name = "urn:oasis:names:tc:xacml:1.0:data-type:x500Name";
            public static readonly string XPathExpression = "urn:oasis:names:tc:xacml:3.0:data-type:xpathExpression";
            public static readonly string IpAddress = "urn:oasis:names:tc:xacml:2.0:data-type:ipAddress";
            public static readonly string DnsName = "urn:oasis:names:tc:xacml:2.0:data-type:dnsName";
        }

        public static class Resources
        {
            public static readonly string Id = "urn:oasis:names:tc:xacml:1.0:resource:resource-id";
            public static readonly string TargetNamespace = "urn:oasis:names:tc:xacml:2.0:resource:target-namespace";
        }

        public static class Actions
        {
            public static readonly string Id = "urn:oasis:names:tc:xacml:1.0:action:action-id";
            public static readonly string ImpliedAction = "urn:oasis:names:tc:xacml:1.0:action:implied-action";
            public static readonly string Namespace = "urn:oasis:names:tc:xacml:1.0:action:action-namespace";
        }

        public static class Functions
        {
            public static readonly string StringEqual = "urn:oasis:names:tc:xacml:1.0:function:string-equal";
            public static readonly string BooleanEqual = "urn:oasis:names:tc:xacml:1.0:function:boolean-equal";
            public static readonly string IntegerEqual = "urn:oasis:names:tc:xacml:1.0:function:integer-equal";
            public static readonly string DoubleEqual = "urn:oasis:names:tc:xacml:1.0:function:double-equal";
            public static readonly string DateEqual = "urn:oasis:names:tc:xacml:1.0:function:date-equal";
            public static readonly string TimeEqual = "urn:oasis:names:tc:xacml:1.0:function:time-equal";
            public static readonly string DateTimeEqual = "urn:oasis:names:tc:xacml:1.0:function:dateTime-equal";

        }
    }
}
