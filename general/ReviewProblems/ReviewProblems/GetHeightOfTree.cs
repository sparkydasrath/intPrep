using System;

namespace ReviewProblems
{
    public class GetHeightOfTree
    {
        public static int GetHeight(TreeNode n)
        {
            if (n == null) return -1;
            return Math.Max(GetHeight(n.Left), GetHeight(n.Right)) + 1;
        }
    }
}