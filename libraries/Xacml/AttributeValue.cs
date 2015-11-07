namespace Xacml
{
    public class AttributeValue
    {
        public string DataType { get; set; }
        public string Value { get; set; }

        public AttributeValue() { }
        public AttributeValue(string dataType, string value)
        {
            DataType = dataType;
            Value = value;
        }
    }
}