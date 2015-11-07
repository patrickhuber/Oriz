using System.Collections.Generic;

namespace Xacml
{
    public class AllOf
    {
        public ICollection<Match> Matches { get; set; }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var match in Matches)
                if (match.Evaluate(authorizationContext) == MatchResult.False)
                    return MatchResult.False;
            return MatchResult.True;
        }        
    }
}
