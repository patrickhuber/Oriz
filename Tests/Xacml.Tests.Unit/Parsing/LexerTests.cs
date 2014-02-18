using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Parsing;

namespace Xacml.Tests.Unit.Parsing
{
    /// <summary>
    /// Summary description for LexerTests
    /// </summary>
    [TestClass]
    public class LexerTests
    {
        public LexerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Lexer_Tokenize_YearMonthDuration()
        {
            const string PeriodDelimiterTokenType = "PERIOD_DELIM";
            const string YearDelimiterTokenType = "YEAR_DELIM";
            const string MonthDelimiterTokenType = "MONTH_DELIM";
            const string NumberTokenType = "NUMBER";
            const string DashTokenType = "DASH";

            ILexer lexer = new Lexer();
            lexer.AddTokenDefinition(new RegexTokenDefinition(PeriodDelimiterTokenType, "[P]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(YearDelimiterTokenType, "[Y]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(MonthDelimiterTokenType, "[M]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(NumberTokenType, @"\d+"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(DashTokenType, "[-]"));

            int index = 0;
            foreach (var token in lexer.Tokenize("-P20Y6M"))
            {
                if (index == 0)
                    AssertTokenEqual("P", PeriodDelimiterTokenType, token);
                else if (index == 1)
                    AssertTokenEqual("20", NumberTokenType, token);
                else if (index == 2)
                    AssertTokenEqual("Y", YearDelimiterTokenType, token);
                else if (index == 3)
                    AssertTokenEqual("6", NumberTokenType, token);
                else if (index == 4)
                    AssertTokenEqual("M", MonthDelimiterTokenType, token);
                index++;
            }
        }

        [TestMethod]
        public void Lexer_IpAddress_Tokens()
        {
            const string PeriodTokenType = "PERIOD";
            const string NumberTokenType = "NUMBER";

            ILexer lexer = new Lexer();
            lexer.AddTokenDefinition(new RegexTokenDefinition(PeriodTokenType, "[.]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(NumberTokenType, @"\d+"));

            int index = 0;
            foreach (var token in lexer.Tokenize("192.168.1.1"))
            {
                if (index == 0)
                    AssertTokenEqual("192", NumberTokenType, token);                

                else if(index == 2)
                    AssertTokenEqual("168", NumberTokenType, token);                
                
                else if (index == 4)
                    AssertTokenEqual("1", NumberTokenType, token);                

                else if (index == 6)                
                    AssertTokenEqual("1", NumberTokenType, token);                

                else if (index % 2 == 0)                
                    AssertTokenEqual(".", PeriodTokenType, token);                
                index++;
            }
        }

        public static void AssertTokenEqual(string expectedData, string expectedTokenType, Token token)
        {
            Assert.AreEqual(expectedData, token.Data);
            Assert.AreEqual(expectedTokenType, token.Type);
        }
    }
}
