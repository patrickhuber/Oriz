using Oriz.Schema;
using System;

namespace Oriz.DataTypes
{
    public class DateType : AttributeValue
    {
        private DateTimeOffset _date;

        public DateType(DateTimeOffset date) 
            : base(Identifiers.DataTypes.Date, date.ToString("YYYY-MM-DD") ){ }
    }
}
