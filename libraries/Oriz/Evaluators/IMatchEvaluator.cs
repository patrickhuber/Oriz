using Oriz;
using Oriz.Schema;

namespace Oriz.Evaluators
{
    public interface IMatchEvaluator 
    {
        string Id { get; }
        MatchResult Evaluate(Match match, AuthorizationContext authorizationContext);
    }
}