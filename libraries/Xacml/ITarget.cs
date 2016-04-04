using System.Collections.Generic;

namespace Xacml
{
    public interface ITarget
    {
        IEnumerable<AnyOf> AnyOf { get; }

        MatchResult Evaluate(AuthorizationContext authorizationContext);
    }
}