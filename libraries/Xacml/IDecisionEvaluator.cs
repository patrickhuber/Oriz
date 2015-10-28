using System.Collections.Generic;

namespace Xacml
{
    public interface IDecisionEvaluator
    {
        Decision Evaluate(AuthorizationContext authorizationContext);
    }
}