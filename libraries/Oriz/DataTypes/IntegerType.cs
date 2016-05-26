using Oriz.Schema;

namespace Oriz.DataTypes
{
    public class IntegerType : AttributeValue
    {
        public IntegerType(string value) 
            : base(Identifiers.DataTypes.Integer, value)
        {
        }
    }
}
