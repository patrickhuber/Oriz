using Oriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz.Schema
{
    public class Match
    {
        public AttributeDesignator AttributeDesignator { get; private set; }
        public AttributeValue AttributeValue { get; private set; }
        public string Id { get; private set; }

        public Match(
            string id,
            AttributeDesignator designator,
            AttributeValue value)
        {
            AttributeDesignator = designator;
            AttributeValue = value;
            Id = id;
        }
    }
}
