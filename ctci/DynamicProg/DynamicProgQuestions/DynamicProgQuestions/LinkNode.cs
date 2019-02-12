using System.Collections.Generic;

namespace DynamicProgQuestions
{
    public static class LinkNodeUtil
    {
        public static List<int> Print(LinkNode n)
        {
            List<int> l = new List<int>();
            if (n == null) return l;
            while (n.Next != null)
            {
                l.Add(n.Data);
                n = n.Next;
            }

            l.Add(n.Data);  // get the last node as it is skipped when the while loop terminates
            return l;
        }
    }

    public class LinkNode
    {
        public LinkNode(int val) => Data = val;

        public int Count { get; set; }
        public int Data { get; set; }
        public LinkNode Head { get; set; }
        public LinkNode Next { get; set; }
        public LinkNode Tail { get; set; }

        public override string ToString() => Data.ToString();
    }
}