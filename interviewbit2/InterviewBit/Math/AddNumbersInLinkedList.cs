using LinkedLists;

namespace Math
{
    public class AddNumbersInLinkedList
    {
        /*https://leetcode.com/problems/add-two-numbers/
         *
         * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

           You may assume the two numbers do not contain any leading zero, except the number 0 itself.

           Example:

           Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
           Output: 7 -> 0 -> 8
           Explanation: 342 + 465 = 807.

         */

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // build base list to return
            ListNode dummyHead = new ListNode(0); // head of the list
            ListNode curr = dummyHead;
            ListNode p = l1;
            ListNode q = l2;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = p?.Val ?? 0;
                int y = q?.Val ?? 0;
                int sum = x + y + carry;
                carry = sum / 10;
                curr.Next = new ListNode(sum % 10);
                curr = curr.Next;
                p = p?.Next;
                q = q?.Next;
            }

            if (carry > 0)
                curr.Next = new ListNode(carry);

            return dummyHead.Next;
        }
    }
}