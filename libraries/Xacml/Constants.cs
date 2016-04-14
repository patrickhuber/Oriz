using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml
{
    public static class Constants
    {
        public static class Category
        {
            public static readonly string AccessSubject = "urn:oasis:names:tc:xacml:1.0:subject-category:access-subject";
            public static readonly string Resource = "urn:oasis:names:tc:xacml:3.0:attribute-category:resource";
            public static readonly string Action = "urn:oasis:names:tc:xacml:3.0:attribute-category:action";
            
        }

        public static class Attribute
        {
            public static readonly string SubjectId = "urn:oasis:names:tc:xacml:1.0:subject:subject-id";
            public static readonly string ResourceId = "urn:oasis:names:tc:xacml:1.0:resource:resource-id";
            public static readonly string ActionId = "urn:oasis:names:tc:xacml:1.0:action:action-id";
        }

               
    }

    public static class DataType
    {
        public static readonly string Rfc822Name = "urn:oasis:names:tc:xacml:1.0:data-type:rfc822Name";
        public static readonly string AnyUri = "http://www.w3.org/2001/XMLSchema#anyURI";
        public static readonly string String = "http://www.w3.org/2001/XMLSchema#string";
    }

    public static class Resource
    {
        public static readonly string Id = "urn:oasis:names:tc:xacml:1.0:resource:resource-id";
        public static readonly string TargetNamespace = "urn:oasis:names:tc:xacml:2.0:resource:target-namespace";
    }

    public static class Action
    {
        public static readonly string Id = "urn:oasis:names:tc:xacml:1.0:action:action-id";
        public static readonly string ImpliedAction = "urn:oasis:names:tc:xacml:1.0:action:implied-action";
        public static readonly string Namespace = "urn:oasis:names:tc:xacml:1.0:action:action-namespace";
    }
}
