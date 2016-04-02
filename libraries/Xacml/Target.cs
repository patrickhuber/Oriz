using System.Collections.Generic;

namespace Xacml
{
    public class Target
    {
        public ICollection<AnyOf> AnyOf { get; set; }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var anyOf in AnyOf)
                if (anyOf.Evaluate(authorizationContext) == MatchResult.False)
                    return MatchResult.False;
            return MatchResult.True;
        }       
    }
}