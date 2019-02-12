using System;

namespace ReviewProblems
{
    public class CheckBalanced
    {
        public bool IsBalanced(TreeNode n)
        {
            if (n == null) return true;

            int leftHeight = GetHeightOfTree.GetHeight(n.Left);
            int rightHeight = GetHeightOfTree.GetHeight(n.Right);

            int heightDiff = Math.Abs(leftHeight - rightHeight);
            if (heightDiff > 1) return false;

            return IsBalanced(n.Left) && IsBalanced(n.Right);
        }
    }
}