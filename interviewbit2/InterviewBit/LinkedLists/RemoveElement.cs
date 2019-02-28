namespace LinkedLists
{
    public class RemoveElement
    {
        /*
         203. Remove Linked List Elements
        Easy

        Remove all elements from a linked list of integers that have value val.

        Example:

        Input:  1->2->6->3->4->5->6, val = 6
        Output: 1->2->3->4->5

         */

        public ListNode RemoveElements(ListNode head, int val)
        {
            // preprocess for 6 6 6 1 3 to remove all matching elements in the start of the list
            while (head != null && head.Val == val)
                head = head.Next;

            ListNode origin = head;
            ListNode prev = head;

            while (head != null)
            {
                // use window technique to get range of values to remove
                // ex:  1 2 3 6 6 6 7 8 fix prev and move head until we 'skip' all the nodes we want
                // to remove
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

            return origin;
        }
    }
}