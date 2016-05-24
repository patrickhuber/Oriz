using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz
{
    public interface IRule : IDecisionEvaluator
    {
        string Id { get;  }
        RuleEffect Effect { get;  }
        Target Target { get; }
    }
}
