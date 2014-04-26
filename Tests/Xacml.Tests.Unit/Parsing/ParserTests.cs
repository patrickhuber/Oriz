using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Parsing;
using Moq;
using System.Collections.Generic;

namespace Xacml.Tests.Unit.Parsing
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Test_Parser_Simple_Production()
        {
            const int Start = 0;
            const int HelloPart = 1;
            const int WorldPart = 3;

            var helloTokenDefinition = new AlwaysTrueTokenDefinition("hello");
            var atTokenDefinition = new AlwaysTrueTokenDefinition("at");
            var worldTokenDefinition = new AlwaysTrueTokenDefinition("world");

            var mockLexer = new Mock<ILexer>();
            mockLexer
                .Setup(x => x.Tokenize(It.Is<string>(s => s == "hello@world")))
                .Returns(() =>
                {
                    return new LookaheadEnumerable<Token>( 
                        new List<Token>
                        {
                            new Token { Type= helloTokenDefinition.TokenType, Data="hello", Position=0 },
                            new Token { Type = atTokenDefinition.TokenType, Data="@", Position=5},
                            new Token { Type = worldTokenDefinition.TokenType, Data="world", Position=6}
                        });
                });             

            var helloWorldProduction = new Production(Start, x => 
                { 
                    x.Call(HelloPart);
                    x.Expect(atTokenDefinition);
                    x.Call(WorldPart);
                });
            var helloProduction = new Production(HelloPart, x =>
                {
                    x.Expect(helloTokenDefinition);
                });
            var worldProduction = new Production(WorldPart, x =>
                {
                    x.Expect(worldTokenDefinition);
                });

            var grammar = new Grammar(Start);
            grammar.AddProduction(helloWorldProduction);
            grammar.AddProduction(helloProduction);
            grammar.AddProduction(worldProduction);

            var parser = new Parser(grammar, mockLexer.Object);

            var tree = parser.Parse("hello@world");
            Assert.IsNotNull(tree, "tree is null");
            Assert.IsNotNull(tree.Root, "root is null");
            Assert.IsNotNull(tree.Root.Children, "expected at lease one child for root");
            Assert.IsTrue(tree.Root.Children.Any(), "expected at least one child.");
        }

        [TestMethod]
        public void Test_Parser_Switch_Executes_First_Branch()
        {
            // grammar
            // A-> B | 'x' B 'x'
            // B-> 'y'
            var xTokenDefinition = new AlwaysTrueTokenDefinition("x");
            var yTokenDefinition = new AlwaysTrueTokenDefinition("y");

            var mockLexer = new Mock<ILexer>();
            mockLexer
                .Setup(x => x.Tokenize(It.IsAny<string>()))
                .Returns(() => 
                {
                    return new LookaheadEnumerable<Token>(
                        new List<Token>
                    {
                        new Token{ Type="x", Data="x", Position=0},
                        new Token{ Type="y", Data="y", Position=1},
                        new Token{ Type="x", Data="x", Position=2}
                    });
                });
            const int A = 0;
            const int B = 1;
            
            var productionA = new Production(A, x => 
            {
                x.Switch(s => 
                {
                    s.Case(xTokenDefinition, op => 
                    {
                        op.Call(B);
                        op.Expect(xTokenDefinition);
                    });
                    s.SetDefault(op => 
                    {
                        op.Call(B);
                    });
                });
            });
            var productionB = new Production(B, x => 
            {
                x.Expect(yTokenDefinition);
            });

            var grammar = new Grammar(A);
            grammar.AddProduction(productionA);
            grammar.AddProduction(productionB);

            var parser = new Parser(grammar, mockLexer.Object);
            var syntaxTree = parser.Parse("xyx");
            Assert.IsNotNull(syntaxTree);
            Assert.IsNotNull(syntaxTree.Root);
            var rootChildren = syntaxTree.Root.Children;
            Assert.IsNotNull(rootChildren);
            Assert.IsTrue(rootChildren.Count() == 3);
            var middleNode = rootChildren.ToArray()[1];
            Assert.IsTrue(middleNode.Children.Count() == 1);
        }

        [TestMethod]
        public void Test_Parser_Switch_Executes_Default_Branch()
        {

        }
    }
}
