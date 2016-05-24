using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriz
{
    public class AnyOf
    {
        public IEnumerable<AllOf> AllOf { get; private set; }

        public AnyOf(IEnumerable<AllOf> allOf)
        {
            AllOf = allOf;
        }

        public AnyOf(params AllOf[] allOf)
            : this(allOf as IEnumerable<AllOf>)
        { }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var allOf in AllOf)
                if (allOf.Evaluate(authorizationContext) == MatchResult.True)
                    return MatchResult.True;
            return MatchResult.False;
        }
        
    }
}
