using System;

namespace lc_2021_01
{
    public class LinkedListEx
    {
        public ListNode GenListWithoutCycle()
        {
            // 6 nodes and the cycle starts at 3
            ListNode node1 = new(1);
            ListNode node2 = new(2);
            ListNode node3 = new(3);
            ListNode node4 = new(4);
            ListNode node5 = new(5);
            ListNode node6 = new(6);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;

            return node1;
        }

        public ListNode Reverse(ListNode head)
        {
            Console.Write($"Working on node {head?.Value} {Environment.NewLine}");
            if (head.Next == null) return head;
            ListNode last = Reverse(head.Next);
            Console.WriteLine($"Last = {last?.Value}");
            head.Next.Next = head;
            head.Next = null;
            return last;
        }

        public ListNode GenListWithCycle()
        {
            // 6 nodes and the cycle starts at 3
            ListNode node1 = new(1);
            ListNode node2 = new(2);
            ListNode node3 = new(3);
            ListNode node4 = new(4);
            ListNode node5 = new(5);
            ListNode node6 = new(6);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node3;

            return node1;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode slow;
            ListNode fast = slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow) return true;
            }
            return false;
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow;
            ListNode fast = slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow) break;
            }
            //The above code is similar to the hascycle function
            slow = head;
            while (slow != fast)
            {
                fast = fast.Next;
                slow = slow.Next;
            }
            return slow;
        }

        public ListNode FindMidpoint(ListNode head)
        {
            ListNode slow;
            ListNode fast = slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            //slow is in the middle
            return slow;
        }
    }
}