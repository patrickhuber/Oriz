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

        public bool Evaluate(ICollection<AttributeCategory> attributeCategories)
        {
            foreach (var allOf in AllOf)
                if (allOf.Evaluate(attributeCategories))
                    return true;
            return false;
        }
        
    }
}
