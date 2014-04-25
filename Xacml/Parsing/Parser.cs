using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Parser
    {
        private IDictionary<int, Production> _productions;
        private int _startProductionIdentifier;
        private ILexer _lexer;

        public IEnumerable<Production> Productions
        {
            get { return _productions.Values; }
        }

        public ILexer Lexer { get; private set; }

        public Parser(int startProductionIdentifier, ILexer lexer)
        {
            _productions = new Dictionary<int, Production>();
            _startProductionIdentifier = startProductionIdentifier;
            _lexer = lexer;
        }

        public void AddProduction(Production production)
        {
            _productions.Add(production.Identifier, production);
        }

        public void AddProduction(int identifier, Action<ProductionStep> body)
        {
            _productions.Add(identifier, new Production(identifier, body));
        }

        public SyntaxTree Parse(string input)
        {
            Production production = null;
            if (!_productions.TryGetValue(_startProductionIdentifier, out production))
                throw new Exception("Production not found.");

            var syntaxNode = new SyntaxNode();
            var tokenEnumerable = _lexer.Tokenize(input).GetEnumerator();
            var productionStep = new ProductionStep(this, tokenEnumerable, syntaxNode);
            production.Body(productionStep);
            return new SyntaxTree(productionStep.CurrentNode);
        }
    }
}
