using LinkedLists;

namespace Utils
{
    public static class ListNodeUtils
    {
        public static ListNode GetLinkedList(int[] values)
        {
            ListNode head = null;
            ListNode current = null;
            for (int i = 0; i < values.Length; i++)
            {
                current = new ListNode(values[i]);
                current.Next = current;
                if (head == null)
                    head = current;
                else
                {
                    current.Next = current;
                }
            }

            return head;
        }
    }
}