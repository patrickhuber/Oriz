using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Web.Mvc
{
    public static class MvcConstants
    {
        public static class Identifiers
        {
            private static readonly string SystemWebMvcPrefix = "urn:system:web:mvc:";
            public static readonly string Controller = SystemWebMvcPrefix + "controller";
            public static readonly string Area = SystemWebMvcPrefix + "area";
            public static readonly string Action = SystemWebMvcPrefix + "action";
        }
    }
}
