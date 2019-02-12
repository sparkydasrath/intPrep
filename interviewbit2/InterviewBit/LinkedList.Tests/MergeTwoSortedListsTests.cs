using LinkedLists;
using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    public class MergeTwoSortedListsTests
    {
        [Test]
        public void ShouldMergeTwoListsIter()
        {
            ListNode l1 = new ListNode(1)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(4)
                }
            };

            ListNode l2 = new ListNode(1)
            {
                Next = new ListNode(3)
                {
                    Next = new ListNode(4)
                }
            };

            MergeTwoSortedLists m2 = new MergeTwoSortedLists();
            ListNode result = m2.MergeTwoListsIter(l1, l2);
            Assert.That(result.Val, Is.EqualTo(1));
            Assert.That(result.Next.Val, Is.EqualTo(1));
        }

        [Test]
        public void ShouldMergeTwoListsRecur()
        {
            ListNode l1 = new ListNode(1)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(4)
                }
            };

            ListNode l2 = new ListNode(1)
            {
                Next = new ListNode(3)
                {
                    Next = new ListNode(4)
                }
            };

            MergeTwoSortedLists m2 = new MergeTwoSortedLists();
            ListNode result = m2.MergeTwoListsRecursive(l1, l2);
            Assert.That(result.Val, Is.EqualTo(1));
            Assert.That(result.Next.Val, Is.EqualTo(1));
        }
    }
}