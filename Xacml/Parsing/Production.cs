using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Production
    {
        public int Identifier { get; private set; }
        public Action<ProductionStep> Body { get; private set; }

        public Production(int identifier, Action<ProductionStep> body)
        {
            Identifier = identifier;
            Body = body;
        }
    }
}
