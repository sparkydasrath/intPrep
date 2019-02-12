// ReSharper disable IdentifierTypo
namespace DynamicProgQuestions
{
    public class ReverseLinkedList
    {
        private LinkNode head;

        public ReverseLinkedList() => head = BuildLinkedList();

        public LinkNode BuildLinkedList()
        {
            LinkNode ln = new LinkNode(1);
            ln.Head = ln;
            ln.Next = new LinkNode(2)
            {
                Next = new LinkNode(3)
            };
            return ln;
        }

        // https://www.youtube.com/watch?v=MRe3UsRadKw&t=0s&list=PLamzFoFxwoNhjM4XzXJpszrukwKj3tvDL&index=4
        public void Reverse(LinkNode curr)
        {
            if (curr == null) return;
            if (curr.Next == null)
            {
                head = curr;
                head.Head = curr;
                return;
            }

            Reverse(curr.Next);
            curr.Next.Next = curr;
            curr.Next = null;
        }
    }
}