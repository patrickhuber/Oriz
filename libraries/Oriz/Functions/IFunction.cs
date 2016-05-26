using System.Collections.Generic;
using Oriz.Schema;

namespace Oriz.Functions
{
    public interface IFunction : IEntity
    {
        ICollection<AttributeValue> AttributeValues { get; }

        Attribute Evaulate(Attribute attribute);
    }
}