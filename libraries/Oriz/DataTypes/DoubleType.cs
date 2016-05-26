using Oriz.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.DataTypes
{
    public class DoubleType : AttributeValue
    {
        public DoubleType(string value)
            : base(Identifiers.DataTypes.Double, value)
        {
        }
    }
}
