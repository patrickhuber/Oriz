using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Xacml.Parsing
{
    public class ProductionStep : Xacml.Parsing.IProductionStep
    {
        private Parser _parser;
        private LookaheadEnumerator<Token> _tokenEnumerator;
        public SyntaxNode CurrentNode { get; private set; }
        private Stack<SyntaxNode> _nodeStack;

        public ProductionStep(Parser parser, LookaheadEnumerator<Token> tokenEnumerator, SyntaxNode currentNode)
        {
            _parser = parser;
            CurrentNode = currentNode;
            _tokenEnumerator = tokenEnumerator;
            _nodeStack = new Stack<SyntaxNode>();
        }

        public void Call(int productionId)
        {
            var production = _parser.Productions.FirstOrDefault(x => x.Identifier == productionId);
            
            _nodeStack.Push(CurrentNode);
            CurrentNode = new SyntaxNode();
            production.Body(this);
            var child = CurrentNode;
            CurrentNode = _nodeStack.Pop();
            CurrentNode.AddChild(child);
        }

        public void Expect(TokenDefinition tokenDefinition)
        {
            if (!_tokenEnumerator.MoveNext())
                ThrowUnexpectedEndOfInputFound();
                        
            var token = _tokenEnumerator.Current;
            if (token.Type != tokenDefinition.TokenType)
                ThrowUnexpectedTokenFound(expected: tokenDefinition, found: token);

            var node = new TokenSyntaxNode(token);
            CurrentNode.AddChild(node);
        }

        public void Switch(Action<ProductionSwitch> switchStatement)
        {
            if (!_tokenEnumerator.MoveNext())
                ThrowUnexpectedEndOfInputFound();
            ProductionSwitch productionSwitch = new ProductionSwitch();
            switchStatement.Invoke(productionSwitch);
            var token = _tokenEnumerator.Current;
            this.CurrentNode.AddChild(new TokenSyntaxNode(token));
            var caseStatement = productionSwitch.Cases.FirstOrDefault(x => x.TokenDefinition.TokenType == token.Type);
            if (caseStatement == null)
                caseStatement = productionSwitch.Default;
            if (caseStatement == null)
                ThrowUnexpectedEndOfInputFound(
                    new Exception("Switch evaulation resulted in undetermined behavior. Are you missing a Default Statement?"));
            caseStatement.Body(this);
        }

        public IEnumerable<Token> LookAhead(int count)
        {
            return _tokenEnumerator.Peek(count);
        }

        public bool LookaheadEquals(TokenDefinition tokenDefinition)
        {
            var peek = Peek();
            return peek != null && peek.Type.Equals(tokenDefinition.TokenType);
        }

        public Token Peek()
        {
            return LookAhead(1).FirstOrDefault();
        }

        public void ThrowUnexpectedEndOfInputFound()
        {
            ThrowUnexpectedEndOfInputFound(null);
        }

        public void ThrowUnexpectedEndOfInputFound(Exception innerException)
        {
            int position = _tokenEnumerator.Current.Position;
            const string message = "Unexpected end of input found.";
            if(innerException != null)
                throw new ParseException(
                    position, 
                    message, 
                    innerException);
            throw new ParseException(
                position,
                message);
        }

        public void ThrowUnexpectedTokenFound(TokenDefinition expected, Token found)
        {
            throw new ParseException(found.Position,
                    string.Format("Unexpected token found. Found: {0}, Expected: {1}", found.Type, expected.TokenType));
        }


    }
}
