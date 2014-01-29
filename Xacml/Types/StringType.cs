using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Types
{
    public class StringType : IType, IEquatable<StringType>
    {
        public string Type { get { return Constants.DataTypes.String; } }
        public string Value { get; set; }
        
        public bool Equals(StringType other)
        {
            return this.Value == other.Value;
        }
    }
}
