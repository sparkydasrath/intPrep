namespace Trees.Tests
{
    public class TreeBuilder
    {
        /*
                           10
                       /        \
                     11         -20
                    /  \        /  \
                   15   12     0    9
                              / \
                             16  18
         */

        public TreeNode BuildBinaryTree()
        {
            // https://www.youtube.com/watch?v=elQcrJrfObg
            TreeNode root = new TreeNode(10)
            {
                Left = new TreeNode(11)
                {
                    Left = new TreeNode(15),
                    Right = new TreeNode(12)
                },

                Right = new TreeNode(-20)
            };
            root.Right.Left = new TreeNode(0)
            {
                Left = new TreeNode(16),
                Right = new TreeNode(18)
            };

            root.Right.Right = new TreeNode(9);

            return root;
        }
    }
}