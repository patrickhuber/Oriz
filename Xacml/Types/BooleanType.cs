using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Types
{
    public class BooleanType : IType, IEquatable<BooleanType>
    {
        public bool Value { get; set; }

        public string Type
        {
            get { return Constants.DataTypes.Boolean; }
        }

        public bool Equals(BooleanType other)
        {
            return this.Value == other.Value;
        }
    }
}
