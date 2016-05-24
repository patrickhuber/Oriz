using System.Collections.Generic;

namespace Oriz
{
    public interface ITarget
    {
        IEnumerable<AnyOf> AnyOf { get; }

        MatchResult Evaluate(AuthorizationContext authorizationContext);
    }
}