using Oriz.Schema;
using System.Collections.Generic;

namespace Oriz.Schema
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
