using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xacml.Parsing;

namespace Xacml.Types
{
    public struct YearMonthDuration
    {
        private long totalMonths;

        public YearMonthDuration(long totalMonths)
        {
            this.totalMonths = totalMonths;
        }               
        
        public YearMonthDuration(int years, int months)
        {
            this.totalMonths = years * 12 + months;
        }

        public long TotalMonths { get { return totalMonths; } }
        public int Months { get { return GetMonthsPart(); } }
        public long Years { get { return GetYearsPart(); } }

        private int GetMonthsPart()
        {
            return (int)(totalMonths % 12L);
        }

        private long GetYearsPart()
        {
            return totalMonths / 12L;
        }

        public override string ToString()
        {
            var years = Years;
            var months = Months;
            return string.Format("{2}P{0}Y{1}M", Math.Abs(years), Math.Abs(months), years < 0 ? "-" : string.Empty);
        }

        public static YearMonthDuration Parse(string input)
        {
            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(input);
                        
            int currentState = 1;
            
            int number = 0;
            int months = 0;
            int years = 0;
            bool minus = false;

            foreach (var token in tokens)
            {
                if (currentState == 1)
                {
                    if (token.Type == Tokenizer.character)
                    {
                        if (token.Data == "P")
                            currentState = 3;
                        else
                            throw UnexpectedTokenException(token);
                    }
                    else if (token.Type == Tokenizer.dash)
                    {
                        minus = true;
                        currentState = 2;
                    }
                    else
                        throw UnexpectedTokenException(token);
                }
                else if (currentState == 2)
                {
                    if (token.Type == Tokenizer.character && token.Data == "P")
                        currentState = 3;
                    else
                        throw UnexpectedTokenException(token);
                }
                else if (currentState == 3)
                {
                    if (token.Type == Tokenizer.number)
                    {       
                        number = Int32.Parse(token.Data);
                        currentState = 4;
                    }
                    else
                        throw UnexpectedTokenException(token);
                }
                else if (currentState == 4)
                {
                    if (token.Type == Tokenizer.character)
                    { 
                        if(token.Data == "Y")
                        {
                            years = number;
                            currentState = 5;
                        }
                        else if (token.Data == "M")
                        {
                            months = number;
                            currentState = 7;
                        }
                        else
                            throw UnexpectedTokenException(token);
                    }
                    else
                        throw UnexpectedTokenException(token);
                }
                else if (currentState == 5)
                {
                    if (token.Type == Tokenizer.number)
                    {
                        number = Int32.Parse(token.Data);
                        currentState = 6;
                    }
                    else
                        throw UnexpectedTokenException(token);
                }
                else if (currentState == 6)
                {
                    if (token.Type == Tokenizer.character && token.Data == "M")
                    {
                        months = number;
                        currentState = 7;
                    }
                    else
                        throw UnexpectedTokenException(token);
                }
            }
            if (currentState != 5 && currentState != 7)
                throw new Exception("Unexpected end of string reached.");

            if (minus)
                return new YearMonthDuration(-years, -months);
            else
                return new YearMonthDuration(years, months);
        }

        private static Exception UnexpectedTokenException(Token token)
        {
            return new Exception(string.Format("Unexpected token {0} found at position {1}", token.Data, token.Position));                
        }

        private class Tokenizer
        {
            public const int unknown = -1;
            public const int dash = 0;
            public const int character = 1;
            public const int number = 2;

            public IEnumerable<Token> Tokenize(string input)
            {
                var tokens = new List<Token>();
                Token currentToken = new Token();
                char lookAhead = '\0';

                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    if (i < input.Length - 1)
                        lookAhead = input[i + 1];
                    else
                        lookAhead = '\0';

                    if (char.IsLetter(c))
                    {
                        if (currentToken.Type == character)
                            currentToken.Data += c;
                        else
                        {
                            if (i > 0)
                                yield return currentToken;
                            currentToken = new Token(character, i, c.ToString());
                        }
                    }
                    else if (char.IsNumber(c))
                    {
                        if (currentToken.Type == number)
                            currentToken.Data += c;
                        else
                        {
                            if (i > 0)
                                yield return currentToken;
                            currentToken = new Token(number, i, c.ToString());
                        }
                    }
                    else if (c == '-')
                    {
                        if (i > 0)
                            yield return currentToken;
                        currentToken = new Token(dash, i, c.ToString());
                    }
                    else
                    {
                        if (i > 0)
                            yield return currentToken;
                        currentToken = new Token(unknown, i, c.ToString());
                    }
                }
                yield return currentToken;
            }
        }
    }
}
