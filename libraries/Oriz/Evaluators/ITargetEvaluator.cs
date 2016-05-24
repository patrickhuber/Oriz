using Oriz.Schema;

namespace Oriz.Evaluators
{
    public interface ITargetEvaluator
    {
        MatchResult Evaluate(Target target, AuthorizationContext context);
    }
}
