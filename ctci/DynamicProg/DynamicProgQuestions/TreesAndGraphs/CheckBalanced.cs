using System;

namespace TreesAndGraphs
{
    public class CheckBalanced
    {
        /*
         * 4.4 Check Balanced: Implement a function to check if a binary tree is balanced. For the purposes of
           this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any
           node never differ by more than one.
           Hints: #2 7, #33, #49, # 705, #724
         */

        public int GetHeight(TreeNode n)
        {
            if (n == null) return -1;
            return Math.Max(GetHeight(n.Left), GetHeight(n.Right)) + 1;
        }

        public bool IsBalanced(TreeNode n)
        {
            if (n == null) return true;
            int heightDiff = GetHeight(n.Left) - GetHeight(n.Right);

            if (Math.Abs(heightDiff) > 1) return false;
            return IsBalanced(n.Left) && IsBalanced(n.Right);
        }
    }
}