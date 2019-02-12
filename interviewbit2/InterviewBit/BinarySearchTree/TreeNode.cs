namespace BinarySearchTree
{
    public class TreeNode
    {
        public TreeNode(int v) => Val = v;

        public TreeNode(int v, int c)
        {
            Val = v;
            Count = c;
            Left = null;
            Right = null;
        }

        public int Count { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Right { get; set; }
        public int Val { get; set; }
        public bool Visited { get; set; }

        public override string ToString() => Val.ToString();
    }

    public class TreeNode<T>
    {
        public TreeNode(T v) => Val = v;

        public TreeNode Left { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Right { get; set; }
        public T Val { get; set; }
        public bool Visited { get; set; }

        public override string ToString() => Val.ToString();
    }
}