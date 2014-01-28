using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml.Functions
{
    public class FunctionResult
    {
        public FunctionResult(StatusType status, string resultType, bool indeterminate, params object[] values)
        {
            Status = status;
            ResultType = resultType;
            Indeterminate = indeterminate;
            Values = values ?? new object[]{};
        }

        public bool Indeterminate { get; private set; }
        
        public object Value 
        { 
            get { return Values.FirstOrDefault(); } 
        }

        public IEnumerable<object> Values { get; private set; }
        public string ResultType { get; private set; }
        public StatusType Status { get; private set; }
    }
}
