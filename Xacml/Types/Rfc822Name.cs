using System;
using System.Linq;
using Xacml.Parsing;
namespace Xacml.Types
{
    [Obsolete("Use System.Net.MailAddress", true)]
    public struct Rfc822Name : IEquatable<Rfc822Name>
    {
        public readonly string LocalPart;
        public readonly string DomainPart;

        public Rfc822Name(string localPart, string domainPart)
        {
            this.LocalPart = localPart;
            this.DomainPart = domainPart;
        }

        public override bool Equals(object obj)
        {
            if (obj is Rfc822Name)
            {
                var rfc822Name = (Rfc822Name)obj;
                return Equals(rfc822Name);
            }
            return false;
        }

        /// <summary>
        ///     RFC822Name = LocalPart '@' DomainPart
        ///     LocalPart = '(' Comment ')' LocalPartBody | LocalPartBody [ '(' Comment ')' ]        
        ///     Comment = WORD+
        ///     LocalPartBody = LocalPartSection [ '.' LocalPartSection ]+
        ///     LocalPartSection = '"' SPECIAL_WORD+ '"' | WORD+
        ///     DomainPart = HostName | '[' IP ']'
        ///     IP = 'IPV6' System.IPAddress | System.IPAddress
        ///     HostName = 
        /// </summary>
        /// <param name="rfc822NameString"></param>
        /// <returns></returns>
        public static Rfc822Name Parse(string rfc822NameString)
        {
            const string WORD = "WORD";
            const string PERIOD = "PERIOD";
            const string AT_SYMBOL = "AT_SYMBOL";
            const string QUOTE = "QUOTE";
            const string SPECIAL_WORD = "SPECIAL_WORD";
            const string OPEN_PARENTHESIS = "OPEN_PARENTHESIS";
            const string CLOSE_PARENTHESIS = "CLOSE_PARENTHESIS";

            var wordTokenDefinition = new RegexTokenDefinition(WORD, @"([a-zA-Z]|[0-9]|[!#$%&'*+-/=?^_`{|}~])+");
            var periodTokenDefinition = new RegexTokenDefinition(PERIOD, @"[.]");
            var quoteTokenDefinition = new RegexTokenDefinition(QUOTE, @"""");
            var atSymbolTokenDefinition = new RegexTokenDefinition(AT_SYMBOL, @"[@]");
            var specialWordTokenDefinition = new RegexTokenDefinition(SPECIAL_WORD, @"([a-zA-Z]|[0-9]|[!#$%&'*+-/=?^_`{|}~]|(\\)|(\"")|[ (),:;<>@])+");
            var openParenthesis = new RegexTokenDefinition(OPEN_PARENTHESIS, "[(]");
            var closeParenthesis = new RegexTokenDefinition(CLOSE_PARENTHESIS, "[(]");

            Grammar grammar = new Grammar((int)Rfc822NameStates.Rfc822Name);
            grammar.AddTokenDefinition(wordTokenDefinition);
            grammar.AddTokenDefinition(periodTokenDefinition);
            grammar.AddTokenDefinition(quoteTokenDefinition);
            grammar.AddTokenDefinition(atSymbolTokenDefinition);
            grammar.AddTokenDefinition(specialWordTokenDefinition);

            var rfc822Name = new Production((int)Rfc822NameStates.Rfc822Name, x =>
            {
                x.Call((int)Rfc822NameStates.LocalPart);
                x.Expect(atSymbolTokenDefinition);
                x.Call((int)Rfc822NameStates.DomainPart);
            });
            
            var localPart = new Production((int)Rfc822NameStates.LocalPart, x => 
            {                
                if (x.LookaheadEquals(openParenthesis))
                {   
                    x.Expect(openParenthesis);
                    x.Call((int)Rfc822NameStates.Comment);
                    x.Expect(closeParenthesis);
                }
                else
                {
                    x.Call((int)Rfc822NameStates.LocalPartBody);                    
                    if (x.LookaheadEquals(openParenthesis))
                    {
                        x.Expect(openParenthesis);
                        x.Call((int)Rfc822NameStates.Comment);
                        x.Expect(closeParenthesis);
                    }
                }
            });
            
            var localPartBody = new Production((int)Rfc822NameStates.LocalPartBody, x => 
            {
                x.Call((int)Rfc822NameStates.LocalPartSection);
                while(x.LookaheadEquals(periodTokenDefinition))
                {
                    x.Expect(periodTokenDefinition);
                    x.Call((int)Rfc822NameStates.LocalPartSection);
                }
            });
            
            var localPartSection = new Production((int)Rfc822NameStates.LocalPartSection, x => 
            {
                if (x.LookaheadEquals(quoteTokenDefinition))
                {
                    x.Expect(quoteTokenDefinition);
                    x.Expect(specialWordTokenDefinition);
                    x.Expect(quoteTokenDefinition);
                }
                else
                {                    
                    x.Expect(wordTokenDefinition);
                }
            });
            
            var domainPart = new Production((int)Rfc822NameStates.DomainPart, x=> { });
            
            grammar.AddProduction(rfc822Name);
            grammar.AddProduction(localPart);
            grammar.AddProduction(localPartBody);
            grammar.AddProduction(localPartSection);
            grammar.AddProduction(domainPart);

            var parser = new Parser(grammar);            
            var syntaxTree = parser.Parse(rfc822NameString);

            return MapSyntaxTreeToRfc822Name(syntaxTree);
        }
        
        private static Rfc822Name MapSyntaxTreeToRfc822Name(SyntaxTree sytaxTree)
        {
            return default(Rfc822Name);
        }

        private enum Rfc822NameStates : int
        { 
            Rfc822Name,
            AtSymbol,
            LocalPart,
            DomainPart,
            Comment,
            LocalPartBody,         
            LocalPartSection,
            LocalPartName,
            SpecialLocalPartName,                       
        }

        public bool Equals(Rfc822Name other)
        {
            return this.LocalPart.Equals(other.LocalPart, StringComparison.CurrentCulture)
                && DomainPart.Equals(other.DomainPart, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.LocalPart.GetHashCode() ^ this.DomainPart.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}@{1}", LocalPart, DomainPart);
        }
    }
}