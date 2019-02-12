namespace TreesAndGraphs
{
    public class InOrderSuccessor
    {
        /*
         * 4.6 Successor: Write an algorithm to find the "next" node (i .e., in-order successor) of a given node in a
           binary search tree. You may assume that each node has a link to its parent.
           Hints: #79, #91
         */

        public TreeNode InOrderSuccessorSearch(TreeNode n)
        {
            if (n == null) return null;
            if (n.Right != null) return LeftMostChild(n);

            TreeNode q = n;
            TreeNode x = q.Parent;
            while (x != null && x.Left != q)
            {
                q = x;
                x = x.Parent;
            }
            return x;
        }

        public TreeNode LeftMostChild(TreeNode n)
        {
            if (n == null) return null;
            while (n.Left != null)
            {
                n = n.Left;
            }

            return n;
        }
    }
}