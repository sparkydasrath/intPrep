namespace lc_2021_01
{
    public class ListNode
    {
        public ListNode Next { get; set; }
        public object Value { get; set; }

        public ListNode(object value = null, ListNode next = null)
        {
            Value = value;
            Next = next;
        }
    }
}