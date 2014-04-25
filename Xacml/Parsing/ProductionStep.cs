using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Xacml.Parsing
{
    public class ProductionStep
    {
        private Parser _parser;
        private IEnumerator<Token> _tokenEnumerator;
        public SyntaxNode CurrentNode { get; private set; }

        public ProductionStep(Parser parser, IEnumerator<Token> tokenEnumerator, SyntaxNode currentNode)
        {
            _parser = parser;
            CurrentNode = currentNode;
            _tokenEnumerator = tokenEnumerator;
        }

        public void Call(int productionId)
        {
            var production = _parser.Productions.FirstOrDefault(x => x.Identifier == productionId);
            var parent = CurrentNode;
            CurrentNode = new SyntaxNode();
            CurrentNode.AddChild(parent);
            production.Body(this);
        }

        public void Expect(TokenDefinition tokenDefinition)
        {
            if (!_tokenEnumerator.MoveNext())
                throw new ParseException(_tokenEnumerator.Current.Position, "Unexpected end of input found.");
                        
            var token = _tokenEnumerator.Current;
            if (token.Type != tokenDefinition.TokenType)
                throw new ParseException(token.Position, 
                    string.Format("Unexpected token found. Found: {0}, Expected: {1}", token.Type, tokenDefinition.TokenType));

            var node = new TokenSyntaxNode(token);
            CurrentNode.AddChild(node);
        }
    }
}
