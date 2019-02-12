using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class SortedLinkedListToBstTests
    {
        [Test]
        public void BuildTreeFromSortedLinkedList()
        {
            SortedLinkedListToBst liToBst = new SortedLinkedListToBst();

            TreeNode n1 = liToBst.SortedListToBst(GetList1(new[] { -10, -3, 0, 5, 9 }));
            Assert.That(n1, Is.Not.Null);
            Assert.That(n1.Val, Is.EqualTo(0));
            Assert.That(n1.Left.Val, Is.EqualTo(-3));
            Assert.That(n1.Right.Val, Is.EqualTo(9));
        }

        private ListNode GetList1(int[] values)
        {
            ListNode ln = new ListNode(values[0])
            {
                Next = new ListNode(values[1])
                {
                    Next = new ListNode(values[2])
                }
            };
            ln.Next.Next.Next = new ListNode(values[3])
            {
                Next = new ListNode(values[4])
            };

            return ln;
        }
    }
}