using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class ProductionCase
    {
        public TokenDefinition TokenDefinition { get; set; }

        public Action<IProductionStep> Body { get; set; }
    }
}
