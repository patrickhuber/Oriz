namespace Oriz
{
    public class AttributeValue
    {
        public string DataType { get; private set; }
        public string Value { get; private set; }
        
        public AttributeValue(string dataType, string value)
        {
            DataType = dataType;
            Value = value;
        }
    }
}