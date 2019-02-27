namespace LinkedLists
{
    public class RotateList
    {
        /*
         Given a linked list, rotate the list to the right by k places, where k is non-negative.

        Example 1:

        Input: 1->2->3->4->5->NULL, k = 2
        Output: 4->5->1->2->3->NULL
        Explanation:
        rotate 1 steps to the right: 5->1->2->3->4->NULL
        rotate 2 steps to the right: 4->5->1->2->3->NULL

        Example 2:

        Input: 0->1->2->NULL, k = 4
        Output: 2->0->1->NULL
        Explanation:
        rotate 1 steps to the right: 2->0->1->NULL
        rotate 2 steps to the right: 1->2->0->NULL
        rotate 3 steps to the right: 0->1->2->NULL
        rotate 4 steps to the right: 2->0->1->NULL

         */

        public ListNode RotateRight(ListNode head, int k)
        {
            /*
             https://leetcode.com/articles/rotate-list/#
             You still need to count all the nodes, but the trick here is to close the linked list and make it into a ring
             But we have enough info to know where we need to 'break' the ring to get the rotation

            from LC
            The algorithm is quite straightforward :

                1. Find the old tail and connect it with the head old_tail.next = head to close the ring. Compute the length of the list n at the same time.
                2. Find the new tail, which is (n - k % n - 1)th node from the head and the new head, which is (n - k % n)th node.
                3. Break the ring new_tail.next = None and return new_head.

             */

            if (head == null) return null;
            if (head.Next == null) return head; // only 1 item in list

            int totalNodes = 1;
            ListNode oldTail = head;
            while (oldTail.Next != null)
            {
                totalNodes++;
                oldTail = oldTail.Next;
            }

            // close ring
            oldTail.Next = head;

            /*
                find new tail : (n - k % n - 1)th node and
                find new head : (n - k % n)th node
            */
            int newTailIndex = totalNodes - k % totalNodes - 1;
            ListNode newTail = head;
            for (int i = 0; i < newTailIndex; i++)
                newTail = newTail.Next;
            ListNode newHead = newTail.Next;

            // break ring
            newTail.Next = null;

            return newHead;
        }

        public ListNode RotateRightMine(ListNode head, int k)
        {
            // my intuition was right but there was a smarter way to do it

            if (head == null) return null;
            if (head.Next == null) return head; // only 1 item in list

            // walk list to get count

            int count = 1;
            while (head.Next != null)
            {
                count++;
                head = head.Next;
            }

            // if k > count, just get the bit that needs rotating
            if (k > count)
            {
                int rem = count % k;
                if (rem == 0) return head; // we are trying to rotate the list a multiple of it's length, so pointless
                k = rem;
            }

            // now walk list until count - k
            ListNode tempHead = head; // save a reference to this so we can easily connect to it later
            ListNode left = head;
            ListNode right = null;
            int rotateCount = 1;
            while (left.Next != null)
            {
                rotateCount++;
                if (rotateCount == count - k && left.Next != null)
                    right = head.Next;
                left = left.Next;
            }

            // at this point we have two lists, left and right
            left.Next = null;
            right.Next = tempHead;

            return tempHead;
        }
    }
}