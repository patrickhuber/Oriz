using System.Collections.Generic;

namespace Xacml
{
    public class Target : ITarget
    {
        public IEnumerable<AnyOf> AnyOf { get; private set; }

        public Target(IEnumerable<AnyOf> anyOf)
        {
            AnyOf = anyOf;
        }

        public Target(params AnyOf[] anyOf)
            : this(anyOf as IEnumerable<AnyOf>)
        { }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var anyOf in AnyOf)
                if (anyOf.Evaluate(authorizationContext) == MatchResult.False)
                    return MatchResult.False;
            return MatchResult.True;
        }       
    }
}