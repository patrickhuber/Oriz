using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class ProductionSwitch : Xacml.Parsing.IProductionSwitch
    {
        private IList<ProductionCase> _cases;
        public IEnumerable<ProductionCase> Cases { get { return _cases; } }
        public ProductionCase Default { get; private set; }

        public ProductionSwitch()
        {
            _cases = new List<ProductionCase>();
        }                

        public void Case(TokenDefinition tokenDefinition, Action<IProductionStep> body)
        {
            _cases.Add(new ProductionCase 
            {
                TokenDefinition = tokenDefinition,
                Body = body
            });
        }

        public void SetDefault(Action<IProductionStep> body)
        {
            Default = new ProductionCase {  Body = body };
        }
    }
}
