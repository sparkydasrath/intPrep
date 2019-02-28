namespace BinarySearchTree
{
    public class ValidateBst
    {
        /*

            98. Validate Binary Search Tree https://leetcode.com/problems/validate-binary-search-tree/
            Medium

            Given a binary tree, determine if it is a valid binary search tree (BST).

            Assume a BST is defined as follows:

                The left subtree of a node contains only nodes with keys less than the node's key.
                The right subtree of a node contains only nodes with keys greater than the node's key.
                Both the left and right subtrees must also be binary search trees.

            Example 1:

            Input:
                2
               / \
              1   3
            Output: true

            Example 2:

                5
               / \
              1   4
                 / \
                3   6
            Output: false
            Explanation: The input is: [5,1,4,null,null,3,6]. The root node's value
                         is 5 but its right child's value is 4.

         * Valid BST (also phrased as Is Binary Tree a BST)
         * https://www.youtube.com/watch?v=MILxfAbIhrE (tushar - great explanation how the code works)
         *
         */

        private TreeNode prev = null;
        private bool valid = true;

        public bool IsBstValid(TreeNode root) => IsBstValidHelper(root, long.MinValue, long.MaxValue);

        public bool IsBstValid2(TreeNode root)
        {
            // did this with Rakka during study
            IsBstValidHelper2(root);
            return valid;
        }

        public bool IsBstValidHelper(TreeNode root, long min, long max)
        {
            if (root == null) return true;

            /*
             * valid solution from LC (https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/140/introduction-to-a-bst/997/discuss/217286/Simple-Java-solution-beats-100)
             * return (
                   root.Val > min &&
                   root.Val < max &&
                   IsBstValidHelper(root, min, root.Val) &&
                   IsBstValidHelper(root, root.Val, max));
             *
             *
             */

            if (root.Val <= min || root.Val > max) return false;

            return IsBstValidHelper(root, min, root.Val) &&
                   IsBstValidHelper(root, root.Val, max);
        }

        private void IsBstValidHelper2(TreeNode root)
        {
            if (root == null) return;
            /*

                        if (valid == false) return; // <--- optimization to prevent exploring the whole tree
            */

            IsBstValidHelper2(root.Left);
            if (prev != null && prev.Val > root.Val)
            {
                valid = false;
                return;
            }

            prev = root;

            /*

            IsBstValidHelper2(root.Right);*/

            /*if (valid)
                IsBstValidHelper2(root.Right);*/
        }
    }
}