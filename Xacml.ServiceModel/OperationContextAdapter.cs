using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Xacml.ServiceModel
{
    public class OperationContextAdapter : IOperationContext
    {
        private OperationContext operationContext;

        public OperationContextAdapter(OperationContext operationContext)
        {
            this.operationContext = operationContext;
        }

    }
}
