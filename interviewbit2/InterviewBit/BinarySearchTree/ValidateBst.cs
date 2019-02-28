namespace BinarySearchTree
{
    public class ValidateBst
    {
        /*
         * Valid BST (also phrased as Is Binary Tree a BST)
         * https://www.youtube.com/watch?v=MILxfAbIhrE (tushar - great explanation how the code works)
         *
         */

        private TreeNode prev = null;
        private bool valid = true;

        public bool IsBstValid(TreeNode root) => IsBstValidHelper(root, long.MinValue, long.MaxValue);

        public bool IsBstValidHelper(TreeNode root, long min, long max)
        {
            if (root == null) return true;

            /*
             * valid solution from leetcode (https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/140/introduction-to-a-bst/997/discuss/217286/Simple-Java-solution-beats-100)
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

        public bool ISValid(TreeNode root)
        {
            IsValidHelper(root);
            return valid;
        }

        private void IsValidHelper(TreeNode root)
        {
            if (root == null) return;
            if (valid == false) return;

            IsValidHelper(root.Left);
            if (prev != null && prev.Val > root.Val)
            {
                valid = false;
                return;
            }

            prev = root;

            /*

            IsValidHelper(root.Right);*/

            if (valid)
                IsValidHelper(root.Right);
        }
    }
}