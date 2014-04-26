using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Xacml.Parsing
{
    public class ParseException : Exception
    {
        public int Index { get; private set; }

        public ParseException(int index)
            : this()
        {
            Index = index;
        }

        public ParseException()
            : base()
        { }

        public ParseException(int index, string message)
            : this(message)
        {
            Index = index;
        }

        public ParseException(string message)
            : base(message)
        { }

        public ParseException(int index, string message, Exception innerException)
            : base(message, innerException)
        {
            Index = index;
        }

        public ParseException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public ParseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
