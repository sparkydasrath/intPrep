namespace Trees
{
    public class TreeNode
    {
        public TreeNode(int v) => Val = v;

        public TreeNode Left { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Right { get; set; }
        public int Val { get; set; }
        public bool Visited { get; set; }

        public override string ToString() => Val.ToString();
    }
}