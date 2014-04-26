using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xacml.Parsing
{
    public class LookaheadEnumerator<T> : IEnumerator<T>
    {
        private Queue<T> _lookaheadQueue;
        private IEnumerator<T> _innerEnumerator;
        
        public LookaheadEnumerator(IEnumerator<T> innerEnumerator)
        {
            _lookaheadQueue = new Queue<T>();
            _innerEnumerator = innerEnumerator;
        }

        public T Current
        {
            get 
            { 
                return _lookaheadQueue.Count == 0 
                    ? _innerEnumerator.Current 
                    : _lookaheadQueue.Peek(); 
            }
        }

        public void Dispose()
        {
            _innerEnumerator.Dispose();            
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this; }
        }

        public bool MoveNext()
        {
            if (_lookaheadQueue.Count > 0)
            {
                _lookaheadQueue.Dequeue();
                return true;
            }
            return _innerEnumerator.MoveNext();
        }

        public void Reset()
        {
            _lookaheadQueue.Clear();
            _innerEnumerator.Reset();
        }

        public IEnumerable<T> Peek(int length)
        {
            bool needMoreBufferedTokens = _lookaheadQueue.Count < length;
            if (needMoreBufferedTokens)
            {
                var lookaheadLength = length - _lookaheadQueue.Count;
                for (int i = 0; i < lookaheadLength; i++)
                {
                    var canMoveNext = _innerEnumerator.MoveNext();
                    if (!canMoveNext)
                        break;
                    _lookaheadQueue.Enqueue(_innerEnumerator.Current);
                }
            }
            return _lookaheadQueue.Take(length);
        }
    }
}
