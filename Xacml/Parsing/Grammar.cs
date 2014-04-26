using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Grammar
    {
        private IList<Production> _productions;
        private IList<TokenDefinition> _tokenDefinitions;

        public IEnumerable<TokenDefinition> TokenDefinitions { get { return _tokenDefinitions; } }
        public IEnumerable<Production> Productions { get { return _productions; } }

        public Production Start { get; private set; }

        private int _productionStartIdentifier;
        
        public Grammar(int productionStartIdentifier)
        {
            _productions = new List<Production>();
            _tokenDefinitions = new List<TokenDefinition>();
            _productionStartIdentifier = productionStartIdentifier;
        }

        public void AddTokenDefinition(TokenDefinition tokenDefinition)
        {
            _tokenDefinitions.Add(tokenDefinition);
        }

        public void AddProduction(Production production)
        {
            if (production.Identifier == _productionStartIdentifier)
                Start = production;
            _productions.Add(production);
        }
    }
}
