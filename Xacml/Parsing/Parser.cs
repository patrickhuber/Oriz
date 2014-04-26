using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Parser
    {
        private Grammar _grammar;
        private ILexer _lexer;

        public Parser(Grammar grammar, ILexer lexer)
        {
            _grammar = grammar;
            _lexer = lexer;
        }                

        public Parser(Grammar grammar)
            : this(grammar, new Lexer(grammar.TokenDefinitions))
        {
        }                

        public SyntaxTree Parse(string input)
        {
            var production = _grammar.Start;
            if (production == null)
                throw new Exception("Production not found.");

            var syntaxNode = new SyntaxNode();
            var tokenEnumerable = _lexer.Tokenize(input).GetLookaheadEnumerator();
            var productionStep = new ProductionStep(this, tokenEnumerable, syntaxNode);
            production.Body(productionStep);
            return new SyntaxTree(productionStep.CurrentNode);
        }

        public IEnumerable<Production> Productions
        {
            get { return _grammar.Productions; }
        }
    }
}
