using LinkedLists;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Math.Tests
{
    [TestFixture]
    public class AddNumbersInLinkedListTests
    {
        [Test]
        public void ShouldAddNumbersInLinkedListsWhenListsAreSameLength()
        {
            ListNode l1 = new ListNode(2)
            {
                Next = new ListNode(4)
                {
                    Next = new ListNode(3)
                }
            };

            ListNode l2 = new ListNode(5)
            {
                Next = new ListNode(6)
                {
                    Next = new ListNode(4)
                }
            };

            AddNumbersInLinkedList addNumbersInLinkedList = new AddNumbersInLinkedList();
            ListNode result = addNumbersInLinkedList.AddTwoNumbers(l1, l2);
            string strResult = LinkedListsUtils.PrintLinkedList(result);
            Assert.That(strResult, Is.EqualTo("7 0 8"));
        }

        [Test]
        public void ShouldAddNumbersInLinkedListsWhenOneListIsLonger()
        {
            ListNode l1 = new ListNode(2)
            {
                Next = new ListNode(4)
                {
                    Next = new ListNode(3)
                }
            };

            ListNode l2 = new ListNode(5)
            {
                Next = new ListNode(6)
            };

            AddNumbersInLinkedList addNumbersInLinkedList = new AddNumbersInLinkedList();
            ListNode result = addNumbersInLinkedList.AddTwoNumbers(l1, l2);
            string strResult = LinkedListsUtils.PrintLinkedList(result);
            Assert.That(strResult, Is.EqualTo("7 0 4"));
        }
    }
}