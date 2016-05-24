using System.Collections.Generic;

namespace Oriz.Schema
{
    public class Target
    {
        public IEnumerable<AnyOf> AnyOf { get; private set; }

        public Target(IEnumerable<AnyOf> anyOf)
        {
            AnyOf = anyOf;
        }

        public Target(params AnyOf[] anyOf)
            : this(anyOf as IEnumerable<AnyOf>)
        { }   
    }
}