using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.Functions
{
    public class TargetFunction : ITargetFunction
    {
        private IFunction function;

        public TargetFunction(IFunction function)
        {
            this.function = function;
        }

        public bool Evaluate(IEnumerable<AttributeValueType> attributeValues)
        {
            throw new NotImplementedException();
        }
    }
}
