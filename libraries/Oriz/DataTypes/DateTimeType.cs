using Oriz.Schema;
using System;

namespace Oriz.DataTypes
{
    public class DateTimeType 
        : AttributeValue
    {
        private readonly DateTime _value;

        public DateTimeType(DateTime value) 
            : base(Identifiers.DataTypes.DateTime, value.ToString())
        {
            _value = value;
        }

        public override int GetHashCode()
        {
            return HashUtil.ComputeHash(DataType.GetHashCode(), _value.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            var dateTimeType = obj as DateTimeType;
            if (null == dateTimeType)
                return false;
            return _value.Equals(dateTimeType._value);
        }
    }
}
