using LinkedLists;
using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    public class IntersectionOfTwoLinkedListsTests
    {
        [Test]
        public void ShouldFindIntersectionHashmapVersion1()
        {
            IntersectionOfTwoLinkedLists li = new IntersectionOfTwoLinkedLists();
            ListNode list1 = GetLinkedList1(new[] { 0, 9, 1, 2, 4 });
            ListNode list2 = GetLinkedList2(new[] { 3, 2, 4 });

            ListNode result = li.GetIntersectionNodeHashMapVersion(list1, list2);
            Assert.IsNotNull(result);
            Assert.That(result.Val, Is.EqualTo(2));
        }

        [Test]
        public void ShouldFindIntersectionHashmapVersion2()
        {
            IntersectionOfTwoLinkedLists li = new IntersectionOfTwoLinkedLists();
            ListNode list1 = new ListNode(8);
            ListNode list2 = new ListNode(4)
            {
                Next = new ListNode(1)
                {
                    Next = new ListNode(8)
                }
            };
            list2.Next.Next.Next = new ListNode(4)
            {
                Next = new ListNode(5)
            };

            ListNode result = li.GetIntersectionNodeHashMapVersion(list1, list2);
            Assert.IsNotNull(result);
            Assert.That(result.Val, Is.EqualTo(8));
        }

        private ListNode GetLinkedList1(int[] values)
        {
            ListNode root = new ListNode(values[0])
            {
                Next = new ListNode(values[1])
                {
                    Next = new ListNode(values[2])
                }
            };
            root.Next.Next.Next = new ListNode(values[3])
            {
                Next = new ListNode(values[4])
            };

            return root;
        }

        private ListNode GetLinkedList2(int[] values)
        {
            ListNode root = new ListNode(values[0])
            {
                Next = new ListNode(values[1])
                {
                    Next = new ListNode(values[2])
                }
            };

            return root;
        }
    }
}