using Oriz.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.Evaluators
{
    public interface IPolicyEvaluator
    {
        Decision Evaluate(Policy policy, AuthorizationContext context);
        Decision Evaluate(PolicySet policySet, AuthorizationContext context);
    }
}
