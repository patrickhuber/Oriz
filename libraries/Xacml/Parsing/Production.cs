using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Production
    {
        public int Identifier { get; private set; }
        public Action<IProductionStep> Body { get; private set; }

        public Production(int identifier, Action<IProductionStep> body)
        {
            Identifier = identifier;
            Body = body;
        }
    }
}
