using Oriz.Schema;

namespace Oriz.DataTypes
{
    public class BooleanType : AttributeValue
    {
        private readonly bool _value;

        public BooleanType(bool value) 
            : base(Identifiers.DataTypes.Boolean, value.ToString())
        {
            _value = value;
        }
        
        public static implicit operator BooleanType(bool value)
        {
            return new BooleanType(value);
        }

        public static implicit operator bool(BooleanType value)
        {
            return value._value;
        }

        public override int GetHashCode()
        {
            return HashUtil.ComputeHash(
                DataType.GetHashCode(), 
                _value.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if ((object)obj == null)
                return false;
            var booleanType = obj as BooleanType;
            if ((object)booleanType == null)
                return false;

            return _value == booleanType._value;
        }
    }
}
