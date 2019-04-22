using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    internal class BinaryTreeZigzagLevelOrderTraversal
    {
        /*
        103. Binary Tree Zigzag Level Order Traversal https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
Medium

Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7

return its zigzag level order traversal as:

[
  [3],
  [20,9],
  [15,7]
]

         */

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            IList<IList<int>> results = new List<IList<int>>();
            IList<TreeNode> temp = new List<TreeNode>();
            IList<TreeNode> temp2 = new List<TreeNode>();

            // base case to kick off iteration
            temp.Add(root);
            results.Add(new List<int>() { root.Val });
            int depth = 1;
            while (true)
            {
                temp2.Clear();

                if (temp.Count == 0) break;

                foreach (TreeNode t in temp)
                {
                    if (t.Left != null) temp2.Add(t.Left);
                    if (t.Right != null) temp2.Add(t.Right);
                }

                if (depth % 2 == 0)
                    results.Add(temp2.Select(t => t.Val).ToList());
                else
                    results.Add(temp2.Select(t => t.Val).Reverse().ToList());

                depth++;
                temp = new List<TreeNode>(temp2);
            }

            return results;
        }
    }
}