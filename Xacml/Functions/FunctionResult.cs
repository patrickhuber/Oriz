using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;
using Xacml.Types;

namespace Xacml.Functions
{
    public class FunctionResult
    {
        public FunctionResult(StatusType status, bool indeterminate, IType value)
        {
            Status = status;
            Indeterminate = indeterminate;
            Value = value;
        }

        public bool Indeterminate { get; private set; }
        public IType Value { get; private set; }
        public StatusType Status { get; private set; }
    }
}
