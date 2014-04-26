using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class AnyOfType
    {
        public AnyOfType()
        { }
        public AnyOfType(params AllOfType[] allOf)
        {
            AllOf = allOf;
        }
    }
}
