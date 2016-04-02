using System.Collections.Generic;

namespace Xacml
{
    public class AttributeCategory
    {
        public string Id { get; set; }
        public ICollection<Attribute> Attributes { get; set; }

        public AttributeCategory() { }
        public AttributeCategory(string id, params Attribute[] attributes)
        {
            Id = id;
            Attributes = attributes;
        }
    }
}
