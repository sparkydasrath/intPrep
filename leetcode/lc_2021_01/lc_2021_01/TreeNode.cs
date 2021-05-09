namespace lc_2021_01
{
    public class TreeNode
    {
        public object Value { get; set; }

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(object value)
        {
            Value = value;
        }
    }
}