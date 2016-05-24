using System.Collections.Generic;

namespace Oriz
{
    public class AllOf
    {
        public IEnumerable<Match> Matches { get; private set; }

        public AllOf(IEnumerable<Match> matches)
        {
            Matches = matches;
        }

        public AllOf(params Match[] matches)
            : this(matches as IEnumerable<Match>)
        { }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var match in Matches)
                if (match.Evaluate(authorizationContext) == MatchResult.False)
                    return MatchResult.False;
            return MatchResult.True;
        }        
    }
}
