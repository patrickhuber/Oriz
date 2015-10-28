using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xacml
{
    public class Attribute
    {
        public string Id { get; set; }
        public ICollection<AttributeValue> Values { get; set; }
    }
}
