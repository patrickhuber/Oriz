using System.Collections.Generic;

namespace Oriz.Schema
{
    public class Attribute
    {
        public string Id { get; set; }

        public ICollection<AttributeValue> Values { get; set; }

        public Attribute() { }

        public Attribute(string id, params AttributeValue[] values)
        {
            Id = id;
            Values = new List<AttributeValue>(values);
        }
    }
}
