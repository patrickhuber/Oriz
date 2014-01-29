using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Types
{
    public class BooleanType : IType, IEquatable<BooleanType>
    {
        public string Type
        {
            get { throw new NotImplementedException(); }
        }

        public bool Equals(BooleanType other)
        {
            throw new NotImplementedException();
        }
    }
}
