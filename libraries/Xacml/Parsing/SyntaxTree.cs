using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class SyntaxTree
    {
        public SyntaxNode Root { get; private set; }
        public SyntaxTree(SyntaxNode root)
        {
            Root = root;
        }
    }
}
