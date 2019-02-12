namespace Trees
{
    public class SymmetryAndMirrorTrees
    {
        /*
         * https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/536/

        Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

           For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

                1
               / \
              2   2
             / \ / \
            3  4 4  3

           But the following [1,2,2,null,3,null,3] is not:

           1
           / \
           2   2
           \   \
           3    3

           Note:
           Bonus points if you could solve it both recursively and iteratively.

            Christ I am an idiot - no idea why I can't get using helper functions -
                the idea here is to start with the root and split the tree into it's left and right subtrees
                to get base cases, then recurse

         (vivek) https://www.youtube.com/watch?v=9jH2L2Ysxko
         */

        public TreeNode ConvertToMirror(TreeNode root)
        {
            if (root == null) return null;
            ConvertToMirror(root.Left);
            ConvertToMirror(root.Right);

            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            return root;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetricHelper(root.Left, root.Right);
        }

        private bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            if (left.Val == right.Val)
            {
                /*
                  left node of left left checked with right node of right now
                   - some tongue twisting logic up in this bitch
                 */
                bool leftResult = IsSymmetricHelper(left.Left, right.Right);
                bool rightResult = IsSymmetricHelper(left.Right, right.Left);
                return leftResult && rightResult;
            }

            return false;
        }
    }
}