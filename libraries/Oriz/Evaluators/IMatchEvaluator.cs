using Oriz;
using Oriz.Schema;

namespace Oriz.Evaluators
{
    public interface IMatchEvaluator  : IEntity
    {
        MatchResult Evaluate(Match match, AuthorizationContext authorizationContext);
    }
}