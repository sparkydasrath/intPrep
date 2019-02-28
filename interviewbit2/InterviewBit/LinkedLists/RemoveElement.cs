namespace LinkedLists
{
    public class RemoveElement
    {
        public ListNode CleanList(ListNode head, int val)
        {
            // preprocess for 6 6 6 1 3

            while (head != null && head.Val == val)
            {
                head = head.Next;
            }

            ListNode orgin = head;
            ListNode prev = head;

            while (head != null)
            {
                while (head.Next != null && head.Next.Val == val)
                    head = head.Next;

                head = head.Next;
                if (prev.Next == head) prev = head;
                else
                {
                    prev.Next = head;
                    prev = prev.Next;
                }
            }

            return orgin;
        }
    }
}