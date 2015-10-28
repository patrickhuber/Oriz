using System.Collections.Generic;

namespace Xacml
{
    public abstract class Match
    {
        public AttributeValue AttributeValue { get; set; }
        public AttributeDesignator AttributeDesignator { get; set; }
        public string Id { get; private set; }

        protected Match(string id)
        {
            Id = id;
        }

        public bool Evaluate(ICollection<AttributeCategory> attributeCategories)
        {
            foreach (var attributeCategory in attributeCategories)
                if (Evaluate(attributeCategory))
                    return true;
            return false;
        }

        private bool Evaluate(
            AttributeCategory attributeCategory)
        {
            if (attributeCategory.Id != AttributeDesignator.Category)
                return false;

            foreach (var attribute in attributeCategory.Attributes)
            {
                if (attribute.Id == AttributeDesignator.AttributeId)
                    return Evaluate(attribute);
            }

            return false;
        }

        protected abstract bool Evaluate(Attribute attribute);
    }
}