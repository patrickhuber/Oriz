using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Parsing;
using Moq;

namespace Xacml.Tests.Unit.Parsing
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Test_Parser_Simple_Production()
        {
            const int Start = 0;
            const int LocalPart = 1;
            const int DomainPart = 3;

            var helloTokenDefinition = new AlwaysTrueTokenDefinition("hello");
            var atTokenDefinition = new AlwaysTrueTokenDefinition("at");
            var worldTokenDefinition = new AlwaysTrueTokenDefinition("world");

            var mockLexer = new Mock<ILexer>();
            mockLexer
                .Setup(x => x.Tokenize(It.Is<string>(s => s == "hello@world")))
                .Returns(() =>
                {
                    return new [] 
                    {
                        new Token { Type= helloTokenDefinition.TokenType, Data="hello", Position=0 },
                        new Token { Type = atTokenDefinition.TokenType, Data="@", Position=5},
                        new Token { Type = worldTokenDefinition.TokenType, Data="world", Position=6}
                    };
                }); 
            var parser = new Parser(Start, mockLexer.Object);
            parser.AddProduction(Start, x => 
                { 
                    x.Call(LocalPart);
                    x.Expect(atTokenDefinition);
                    x.Call(DomainPart);
                });
            parser.AddProduction(LocalPart, x =>
                {
                    x.Expect(helloTokenDefinition);
                });
            parser.AddProduction(DomainPart, x =>
                {
                    x.Expect(worldTokenDefinition);
                });

            var tree = parser.Parse("hello@world");
            Assert.IsNotNull(tree, "tree is null");
            Assert.IsNotNull(tree.Root, "root is null");
            Assert.IsNotNull(tree.Root.Children, "expected at lease one child for root");
            Assert.IsTrue(tree.Root.Children.Any(), "expected at least one child.");
        }
    }
}
