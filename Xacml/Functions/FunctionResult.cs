using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.Functions
{
    public class FunctionResult
    {
        public FunctionResult(StatusType status, string resultType, bool indeterminate, AttributeValueType value)
        {
            Status = status;
            ResultType = resultType;
            Indeterminate = indeterminate;
            Value = value;
        }

        public bool Indeterminate { get; private set; }
        public AttributeValueType Value { get; private set; }
        public string ResultType { get; private set; }
        public StatusType Status { get; private set; }
    }
}
