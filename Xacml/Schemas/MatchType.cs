using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Schemas
{
    public partial class MatchType
    {
        public MatchType() { }

        public MatchType(string matchId, AttributeValueType value, AttributeDesignatorType designator)
        {
            MatchId = matchId;
            Item = designator;
            AttributeValue = value;
        }

        public MatchType(string matchId, AttributeValueType value, AttributeSelectorType selector)
        {
            MatchId = matchId;
            Item = selector;
            AttributeValue = value;
        }
    }
}
