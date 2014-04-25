using System;
using Xacml.Parsing;
namespace Xacml.Types
{
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
        ///     LocalPart = Comment LocalPartBody | LocalPartBody [Comment]
        ///     Comment = '(' CommentBody ')'
        ///     Comment = WORD+
        ///     LocalPartBody = LocalPartSection [ '.' LocalPartSection ]+
        ///     LocalPartSection = '"' SpecialLocalPartName '"' | LocalPartName
        ///     LocalPartName = WORD+
        ///     SpecialLocalPartName = SPECIAL_WORD+
        /// </summary>
        /// <param name="rfc822NameString"></param>
        /// <returns></returns>
        public static Rfc822Name Parse(string rfc822NameString)
        {            
            ILexer lexer = new Lexer();
            const string WORD = "WORD";
            const string PERIOD = "PERIOD";
            const string AT_SYMBOL = "AT_SYMBOL";
            const string QUOTE = "QUOTE";
            const string SPECIAL_WORD = "SPECIAL_WORD";

            var wordTokenDefinition = new RegexTokenDefinition(WORD, @"([a-zA-Z]|[0-9]|[!#$%&'*+-/=?^_`{|}~])+");
            var periodTokenDefinition = new RegexTokenDefinition(PERIOD, @"[.]");
            var quoteTokenDefinition = new RegexTokenDefinition(QUOTE, @"""");
            var atSymbolTokenDefinition = new RegexTokenDefinition(AT_SYMBOL, @"[@]");
            var specialWordTokenDefinition = new RegexTokenDefinition(SPECIAL_WORD, @"([a-zA-Z]|[0-9]|[!#$%&'*+-/=?^_`{|}~]|(\\)|(\"")|[ (),:;<>@])+");
            lexer.AddTokenDefinition(wordTokenDefinition);
            lexer.AddTokenDefinition(periodTokenDefinition);
            lexer.AddTokenDefinition(quoteTokenDefinition);
            lexer.AddTokenDefinition(atSymbolTokenDefinition);
            lexer.AddTokenDefinition(specialWordTokenDefinition);

            var parser = new Parser((int)Rfc822NameStates.Rfc822Name, lexer);
            parser.AddProduction((int)Rfc822NameStates.Rfc822Name, x => 
            {
                x.Call((int)Rfc822NameStates.LocalPart);
                x.Expect(atSymbolTokenDefinition);
                x.Call((int)Rfc822NameStates.DomainPart);
            });
            parser.AddProduction((int)Rfc822NameStates.LocalPart, x => { });
            parser.AddProduction((int)Rfc822NameStates.DomainPart, x => { });

            var syntaxTree = parser.Parse(rfc822NameString);

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
            CommentBody,            
            LocalPartSection,
            LocalPartName,
            SpecialLocalPartName,                       
        }

        public bool Equals(Rfc822Name other)
        {
            return this.LocalPart.Equals(other.LocalPart, StringComparison.CurrentCulture)
                && DomainPart.Equals(other.DomainPart, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}