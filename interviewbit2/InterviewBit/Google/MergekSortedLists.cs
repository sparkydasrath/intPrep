using LinkedLists;

namespace Google
{
    public class MergeKSortedLists
    {
        /*
         * 23. Merge k Sorted Lists https://leetcode.com/problems/merge-k-sorted-lists/
        Hard

        Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

        Example:

        Input:
        [
          1->4->5,
          1->3->4,
          2->6
        ]
        Output: 1->1->2->3->4->4->5->6

         */

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode merged = MergeTwoLists(lists[0], lists[1]);

            for (int i = 2; i < lists.Length; i++)
            {
                merged = MergeTwoLists(merged, lists[i]);
            }

            return merged;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
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
    }
}