using System.Collections.Generic;

namespace Xacml
{
    public class AllOf
    {
        public ICollection<Match> Matches { get; set; }

        public bool Evaluate(ICollection<AttributeCategory> attributeCategories)
        {
            foreach (var match in Matches)
                if (!match.Evaluate(attributeCategories))
                    return false;
            return true;
        }        
    }
}
