using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Parsing;

namespace Xacml.Tests.Unit.Parsing
{
    [TestClass]
    public class LookaheadEnumeratorTests
    {
        [TestMethod]
        public void Test_LookaheadEnumerator_Repeaded_Calls_To_Peek_Read_From_Queue()
        {
            var list = new List<int>{ 1,2,3,4,5,6,7,8,9};
            var enumerable = list.AsEnumerable();
            var enumerator = enumerable.GetEnumerator();
            var lookaheadEnumerator = new LookaheadEnumerator<int>(enumerator);
            Assert.AreEqual(1, lookaheadEnumerator.Peek(1).FirstOrDefault());
            Assert.AreEqual(1, lookaheadEnumerator.Peek(1).FirstOrDefault());
            Assert.AreEqual(1, enumerator.Current);
        }

        [TestMethod]
        public void Test_LookaheadEnumerator_Peek_Past_End_Of_List_Returns_Remaining_List()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var enumerable = list.AsEnumerable();
            var enumerator = enumerable.GetEnumerator();
            var lookaheadEnumerator = new LookaheadEnumerator<int>(enumerator);

            // read past the end of the list
            var lookahead = lookaheadEnumerator.Peek(list.Count + 1);

            Assert.AreEqual(list.Count, lookahead.Count());
            Assert.IsFalse(enumerator.MoveNext());
        }
    }
}
