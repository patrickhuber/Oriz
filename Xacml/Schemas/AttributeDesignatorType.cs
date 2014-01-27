using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class AttributeDesignatorType
    {
        public AttributeDesignatorType() { }
        public AttributeDesignatorType(
            string category,
            string attributeId,
            string dataType) 
        {
            this.Category = category;
            this.AttributeId = attributeId;
            this.DataType = dataType;
        }
    }
}
