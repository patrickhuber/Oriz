using Oriz.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.DataTypes
{
    public class AnyUriType : AttributeValue
    {
        private readonly Uri _uri;
        
        public AnyUriType(Uri value) 
            : base(Identifiers.DataTypes.AnyUri, value.ToString())
        {
            _uri = value;
        }

        public override int GetHashCode()
        {
            return HashUtil.ComputeHash(DataType.GetHashCode(), _uri.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            var otherUriType = obj as AnyUriType;
            if (null == otherUriType)
                return false;
            return _uri.Equals(otherUriType._uri);
        }
    }
}
