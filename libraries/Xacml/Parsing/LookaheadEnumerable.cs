using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class LookaheadEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _innerEnumerable;
        public LookaheadEnumerable(IEnumerable<T> innerEnumerable)
        {
            _innerEnumerable = innerEnumerable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetLookaheadEnumerator();
        }

        public LookaheadEnumerator<T> GetLookaheadEnumerator()
        {
            return new LookaheadEnumerator<T>(_innerEnumerable.GetEnumerator());
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
