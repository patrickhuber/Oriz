using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriz
{
    public class AuthorizationContext
    {
        public ICollection<AttributeCategory> AttributeCategories { get; set; }

        public AuthorizationContext() { }
        public AuthorizationContext(params AttributeCategory[] attributeCategories)
        {
            AttributeCategories = new List<AttributeCategory>(attributeCategories);
        }
    }
}
