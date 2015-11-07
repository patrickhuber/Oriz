using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class AnyOf
    {
        public ICollection<AllOf> AllOf { get; set; }

        public MatchResult Evaluate(AuthorizationContext authorizationContext)
        {
            foreach (var allOf in AllOf)
                if (allOf.Evaluate(authorizationContext) == MatchResult.True)
                    return MatchResult.True;
            return MatchResult.False;
        }
        
    }
}
