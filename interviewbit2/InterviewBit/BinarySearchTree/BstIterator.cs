using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BstIterator
    {
        /*
         * seriously what the fuck
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/140/introduction-to-a-bst/1008/discuss/213340/C-stack-100-O(h)-memory-O(1)-speed
         */
        private readonly Stack<TreeNode> stack;

        public BstIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            BuildStackFromLeft(root);
        }

        public bool HasNext() => stack.Count > 0;

        public int Next()
        {
            /** @return the next smallest number */
            TreeNode node = stack.Pop();
            BuildStackFromLeft(node.Right);
            return node.Val;
        }

        private void BuildStackFromLeft(TreeNode root)
        {
            if (root == null) return;
            stack.Push(root);
            BuildStackFromLeft(root.Left);
        }
    }
}