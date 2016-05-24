using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.Evaluators
{
    public interface IMatchEvaluatorRegistry
    {
        void Register(IMatchEvaluator match);
        IMatchEvaluator Get(string id);
    }
}
