using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.ServiceModel
{
    public class OperationContextHandler : IContextHandler
    {
        private IOperationContext operationContext;

        public OperationContextHandler(IOperationContext operationContext)
        {
            this.operationContext = operationContext;
        }

        public IEnumerable<AttributesType> GetContext()
        {
            var attributes = new List<AttributesType>();
            return attributes;
        }
    }
}
