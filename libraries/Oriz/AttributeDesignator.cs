namespace Oriz
{
    public class AttributeDesignator
    {
        public string Category { get; private set; }
        public string AttributeId { get; private set; }
        public string DataType { get; private set; }

        public AttributeDesignator(string category, string attributeId, string dataType)
        {
            Category = category;
            AttributeId = attributeId;
            DataType = dataType;
        }
    }
}