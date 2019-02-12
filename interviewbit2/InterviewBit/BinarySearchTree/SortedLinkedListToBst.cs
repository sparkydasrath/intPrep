namespace BinarySearchTree
{
    public class SortedLinkedListToBst
    {
        public TreeNode SortedListToBst(ListNode head)
        {
            if (head == null) return null;

            ListNode mid = GetMiddleNode(head);

            TreeNode root = new TreeNode(mid.Val);

            if (mid == head) return root;

            root.Left = SortedListToBst(head);
            root.Right = SortedListToBst(mid.Next);

            return root;
        }

        private ListNode GetMiddleNode(ListNode head)
        {
            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast?.Next != null)
            {
                prev = slow;
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // Handling the case when slowPtr was equal to head.
            if (prev != null) prev.Next = null;

            return slow; // midpoint of the list
        }
    }
}