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

        public TreeNode BuildBinarySearchTree()
        {
            /*
              https://www.ideserve.co.in/learn/serialize-deserialize-binary-search-tree
              https://www.youtube.com/watch?v=H594EV9OuDI

                        5
                     /     \
                    2        7
                   / \      / \
                  1   3    6   8
                       \
                        4
             */

            TreeNode root = new TreeNode(5)
            {
                Left = new TreeNode(2)
                {
                    Left = new TreeNode(1),
                    Right = new TreeNode(3) { Right = new TreeNode(4) }
                }
            };

            root.Right = new TreeNode(7)
            {
                Left = new TreeNode(6),
                Right = new TreeNode(8)
            };
            return root;
        }

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