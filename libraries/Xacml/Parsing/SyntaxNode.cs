using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class SyntaxNode
    {
        private IList<SyntaxNode> _children;
        public IEnumerable<SyntaxNode> Children { get { return _children; } }

        public SyntaxNode()
        {
            _children = new List<SyntaxNode>();
        }

        public void AddChild(SyntaxNode syntaxNode)
        {
            _children.Add(syntaxNode);
        }
    }
}
