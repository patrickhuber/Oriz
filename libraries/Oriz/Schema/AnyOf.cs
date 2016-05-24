using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriz.Schema
{
    public class AnyOf
    {
        public IEnumerable<AllOf> AllOf { get; private set; }

        public AnyOf(IEnumerable<AllOf> allOf)
        {
            AllOf = allOf;
        }

        public AnyOf(params AllOf[] allOf)
            : this(allOf as IEnumerable<AllOf>)
        { }        
    }
}
