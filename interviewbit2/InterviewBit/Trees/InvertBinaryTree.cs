namespace Trees
{
    public class InvertBinaryTree
    {
        public TreeNode InvertTree1(TreeNode root)
        {
            /*
             my shit solution

            if (root.Left == null && root.Right == null)
            {
                return root;
            }

            TreeNode tempLeft = root.Left;
            root.Left = root.Right;
            root.Right = tempLeft;
            return InvertTree(root);
        }*/

            // leetcode solution
            /*
             *  good explanation - this works on LC but I can't seem to trace it through correctly
             * esp the root.right = right & root.left = left as I was expecting the solution to show an actual swap here
             * https://www.youtube.com/watch?v=vdwcCIkLUQI
             */
            if (root == null)
            {
                return null;
            }

            TreeNode left = InvertTree1(root.Left);
            TreeNode right = InvertTree1(root.Right);
            root.Right = right;
            root.Left = left;
            return root;
        }

        public TreeNode InvertTree2(TreeNode root)
        {
            if (root == null) return null;
            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            if (root.Left != null) InvertTree2(root.Left);
            if (root.Right != null) InvertTree2(root.Right);

            return root;
        }
    }
}