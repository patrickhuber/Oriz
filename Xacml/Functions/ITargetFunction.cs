using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.Functions
{
    public interface ITargetFunction
    {
        bool Evaluate(IEnumerable<AttributeValueType> attributeValues);
    }
}
