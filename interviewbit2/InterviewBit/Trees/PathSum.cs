using System.Collections.Generic;

namespace Trees
{
    public class PathSum
    {
        /*
         * https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/537/

        Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

        Note: A leaf is a node with no children.

        Example:

        Given the below binary tree and sum = 22,

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1

        return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

            SOLUTION:
            (tushar) https://www.youtube.com/watch?v=Jg4E4KZstFE
            (vivek)

         */

        public bool HasPathSum(TreeNode root, int sum, List<int> results)
        {
            /* use pre-order traversal and subtract the node value from the sum
                once you get to a leaf node, check if the value of the adjusted sum == node value
                return true if equal
            */
            if (root == null) return false;
            if (root.Left == null && root.Right == null) // leaf
            {
                if (root.Val == sum)
                {
                    results.Add(root.Val);
                    return true;
                }

                return false;
            }

            if (HasPathSum(root.Left, sum - root.Val, results))
            {
                results.Add(root.Val);
                return true;
            }

            if (HasPathSum(root.Right, sum - root.Val, results))
            {
                results.Add(root.Val);
                return true;
            }

            return false;
        }
    }
}