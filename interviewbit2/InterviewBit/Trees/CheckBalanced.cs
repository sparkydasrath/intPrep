using System;

namespace Trees
{
    public class CheckBalanced
    {
        /*
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/143/appendix-height-balanced-bst/1027/
         */

        public bool IsBalanced(TreeNode n)
        {
            if (n == null) return true;

            int leftHeight = HeightOfTree.GetHeightBottomUp(n.Left);
            int rightHeight = HeightOfTree.GetHeightBottomUp(n.Right);

            int heightDiff = Math.Abs(leftHeight - rightHeight);
            if (heightDiff > 1) return false;

            return IsBalanced(n.Left) && IsBalanced(n.Right);
        }
    }
}