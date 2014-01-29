using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Types;

namespace Xacml.Functions
{
    public class EqualFunction : FunctionBase
    {
        public override FunctionResult Evaluate(IEnumerable<Types.IType> arguments)
        {
            AssertArgumentCount(2, arguments);
            AssertArgumentsHaveSameType(arguments);
            var first = arguments.ElementAt(0) as IEquatable<IType>;
            var second = arguments.ElementAt(1) as IEquatable<IType>;
            if (first == null || second == null)
                throw new ArgumentException("arguments must derive from IEquatable<T>");
            var functionResult = new FunctionResult(
                new Schemas.StatusType { StatusCode = new Schemas.StatusCodeType{ Value = Constants.Status.Ok }},
                false,
                new BooleanType {  Value = first.Equals(second)});
            return functionResult;
        }
    }
}
