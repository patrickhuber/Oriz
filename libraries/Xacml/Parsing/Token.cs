using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class Token
    {
        public Token() 
        {
            Data = string.Empty;
        }
        
        public Token(string type, int position, string data)
        {
            this.Type = type;
            this.Position = position;
            this.Data = data;
        }

        public int Position { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }        
    }
}
