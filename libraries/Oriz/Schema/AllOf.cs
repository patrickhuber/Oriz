using System.Collections.Generic;

namespace Oriz.Schema
{
    public class AllOf
    {
        public IEnumerable<Match> Matches { get; private set; }

        public AllOf(IEnumerable<Match> matches)
        {
            Matches = matches;
        }

        public AllOf(params Match[] matches)
            : this(matches as IEnumerable<Match>)
        { }     
    }
}
