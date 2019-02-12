using LinkedLists;
using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class MergeKSortedListsTests
    {
        [Test]
        public void ShouldMergeKListsUsingMergeTwoLists()
        {
            ListNode l1 = new ListNode(1)
            {
                Next = new ListNode(4)
                {
                    Next = new ListNode(5)
                }
            };

            ListNode l2 = new ListNode(1)
            {
                Next = new ListNode(3)
                {
                    Next = new ListNode(4)
                }
            };

            ListNode l3 = new ListNode(2)
            {
                Next = new ListNode(6)
            };

            ListNode[] nodes = new[] { l1, l2, l3 };

            MergeKSortedLists m2 = new MergeKSortedLists();
            ListNode result = m2.MergeKLists(nodes);
            Assert.That(result.Val, Is.EqualTo(1));
        }
    }
}