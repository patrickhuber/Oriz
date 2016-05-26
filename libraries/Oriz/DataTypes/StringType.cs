using Oriz.Schema;

namespace Oriz.DataTypes
{
    public class StringType : AttributeValue
    {
        public StringType(string value) 
            : base(Identifiers.DataTypes.String, value)
        {
        }

        public override int GetHashCode()
        {
            return HashUtil.ComputeHash(
                DataType.GetHashCode(),
                Value.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            var stringType = obj as StringType;
            if (null == stringType)
                return false;
            return this.Value.Equals(stringType.Value);
        }

        public static implicit operator StringType(string value)
        {
            return new StringType(value);
        }
        
        public static implicit operator string(StringType value)
        {
            return value.Value;
        }

        public static bool operator == (StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return first.Equals(second);
        }

        public static bool operator != (StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return !first.Equals(second);
        }

        public static bool operator < (StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return first.InternalLessThan(second);
        }

        public static bool operator > (StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return first.InternalGreaterThan(second);
        }

        public static bool operator <=(StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return first.InternalLessThanOrEqual(second);
        }

        public static bool operator >=(StringType first, StringType second)
        {
            if (null == first || null == second)
                return false;
            return first.InternalGreaterThanOrEqual(second);
        }

        public static StringType operator +(StringType first, StringType second)
        {
            if (null == first || null == second)
                return null;
            string firstString = first;
            string secondString = second;
            return firstString + secondString;
        }

        public BooleanType GreaterThan(StringType value)
        {
            return InternalGreaterThan(value);
        }

        public BooleanType GreaterThanOrEqual(StringType value)
        {
            return InternalGreaterThanOrEqual(value);
        }

        public BooleanType LessThan(StringType value)
        {
            return InternalLessThan(value);
        }

        public BooleanType LessThanOrEqual(StringType value)
        {
            return InternalLessThanOrEqual(value);
        }

        private bool InternalGreaterThan(StringType value)
        {
            return string.Compare(Value, value.Value, System.StringComparison.Ordinal) > 0;
        }

        private bool InternalGreaterThanOrEqual(StringType value)
        {
            return string.Compare(Value, value.Value, System.StringComparison.Ordinal) >= 0;
        }

        private bool InternalLessThan(StringType value)
        {
            return string.Compare(Value, value.Value, System.StringComparison.Ordinal) < 0;
        }

        private bool InternalLessThanOrEqual(StringType value)
        {
            return string.Compare(Value, value.Value, System.StringComparison.Ordinal) <= 0;
        }

        private bool InternalEqualIgnoreCase(StringType value)
        {
            return Value.Equals(value.Value, System.StringComparison.OrdinalIgnoreCase);
        }

        private string InternalNormalizeSpace()
        {
            return Value.Normalize();
        }

        private string InternalNormalizeSpaceToLowerCase()
        {
            return Value.Normalize().ToLower();
        }
    }
}
