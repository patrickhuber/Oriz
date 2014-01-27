using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class TargetType
    {
        public TargetType() { }
        
        public TargetType(params AnyOfType[] anyOf)
        {
            AnyOf = anyOf;
        }
    }
}
