namespace lc_2021_01
{
    public class LinkedListExRunner
    {
        private readonly LinkedListEx list = new LinkedListEx();
        private ListNode head;

        public LinkedListExRunner()
        {
            head = list.GenListWithoutCycle();
        }

        public ListNode ReverseList()
        {
            return list.Reverse(head);
        }
    }
}