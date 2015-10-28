using System.Collections.Generic;

namespace Xacml
{
    public class Target
    {
        public ICollection<AnyOf> AnyOf { get; set; }

        public bool Evaluate(ICollection<AttributeCategory> attributeCategories)
        {
            foreach (var anyOf in AnyOf)
                if (!anyOf.Evaluate(attributeCategories))
                    return false;
            return true;
        }       
    }
}