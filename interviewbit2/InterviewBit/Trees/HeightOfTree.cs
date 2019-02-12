using System;

namespace Trees
{
    public class HeightOfTree
    {
        // https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/534/

        public int Answer { get; set; }

        public static int GetHeightBottomUp(TreeNode root)
        {
            // "Bottom-up" Solution
            if (root == null) return -1;
            return Math.Max(GetHeightBottomUp(root.Left), GetHeightBottomUp(root.Right)) + 1;
        }

        public int GetHeightBottomUpInstance(TreeNode root)
        {
            // "Bottom-up" Solution
            // NOTE: for the example in TreeVBuilder, the depth = height counting from 0, so the
            // depth is actually 3 and not 4
            if (root == null) return 0;
            return Math.Max(GetHeightBottomUp(root.Left), GetHeightBottomUp(root.Right)) + 1;
        }

        public int GetHeightTopDown(TreeNode root)
        {
            int depth = 0;
            GetHeightTopDownHelper(root, depth);
            return Answer;
        }

        private void GetHeightTopDownHelper(TreeNode root, int depth)
        {
            if (root == null) return;
            Answer = Math.Max(Answer, depth);
            GetHeightTopDownHelper(root.Left, depth + 1);
            GetHeightTopDownHelper(root.Right, depth + 1);
        }
    }
}