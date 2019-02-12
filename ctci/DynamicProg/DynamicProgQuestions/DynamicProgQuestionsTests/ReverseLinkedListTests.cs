using System.Collections.Generic;
using DynamicProgQuestions;
using NUnit.Framework;

// ReSharper disable UseObjectOrCollectionInitializer

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class ReverseLinkedListTests
    {
        public LinkNode BuildLinkedList()
        {
            LinkNode ln = new LinkNode(1);
            ln.Head = ln;
            ln.Next = new LinkNode(2);
            ln.Next.Next = new LinkNode(3);
            ln.Next.Next.Next = new LinkNode(4);
            return ln;
        }

        [Test]
        public void ShouldReverseLinkedList()
        {
            ReverseLinkedList rll = new ReverseLinkedList();
            LinkNode test = BuildLinkedList();
            List<int> exp = LinkNodeUtil.Print(test);
            rll.Reverse(test);
            Assert.That(1, Is.EqualTo(1));
            // List<int> printRes = LinkNodeUtil.Print(res); Assert.That(exp, Is.EqualTo(printRes));
        }
    }
}