using System;
using System.Text;

namespace LinkedLists
{
    public static class LinkedListsUtils
    {
        public static string PrintLinkedList(ListNode li)
        {
            StringBuilder sb = new StringBuilder();
            ListNode curr = li;
            while (curr.Next != null)
            {
                sb.Append(curr.Val + " ");
                curr = curr.Next;
            }
            sb.Append(curr.Val);

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}