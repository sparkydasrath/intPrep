using LinkedLists;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LinkedList.Tests
{
    [TestFixture]
    public class RemoveElementsTests
    {
        [Test]
        public void RemoveElements1()
        {
            RemoveElement re = new RemoveElement();
            ListNode head = new ListNode(6)
            {
                Next = new ListNode(6)
            };
            head.Next.Next = new ListNode(1)
            {
                Next = new ListNode(2)
            };
            head.Next.Next.Next.Next = new ListNode(3)
            {
                Next = new ListNode(6)
            };
            head.Next.Next.Next.Next.Next.Next = new ListNode(6)
            {
                Next = new ListNode(6)
            };

            ListNode result = re.RemoveElements(head, 6);
            Assert.IsNotNull(result);
            Assert.That(result.Val, Is.EqualTo(1));
        }
    }
}