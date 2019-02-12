namespace LinkedLists
{
    public class MergeTwoSortedLists
    {
        public ListNode MergeTwoListsIter(ListNode l1, ListNode l2)
        {
            // maintain an unchanging reference to node ahead of the return node.
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.Val <= l2.Val)
                {
                    prev.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    prev.Next = l2;
                    l2 = l2.Next;
                }
                prev = prev.Next;
            }

            // exactly one of l1 and l2 can be non-null at this point, so connect the non-null list
            // to the end of the merged list.
            prev.Next = l1 ?? l2;

            return prehead.Next;
        }

        public ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            if (l1.Val < l2.Val)
            {
                l1.Next = MergeTwoListsRecursive(l1.Next, l2);
                return l1;
            }

            l2.Next = MergeTwoListsRecursive(l1, l2.Next);
            return l2;
        }
    }
}