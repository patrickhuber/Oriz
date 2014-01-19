using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml
{
    public class Descriptor : Descriptor<string>
    {
    }
    public abstract class Descriptor<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
    }
}
