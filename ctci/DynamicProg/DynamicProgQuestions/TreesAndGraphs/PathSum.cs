using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class PathSum
    {
        /*
         * 4.12 Paths with Sum: You are given a binary tree in which each node contains an integer value (which
           might be positive or negative). Design an algorithm to count the number of paths that sum to a
           given value. The path does not need to start or end at the root or a leaf, but it must go downwards
           (traveling only from parent nodes to child nodes).
           Hints: #6, #14, #52, #68, #77, #87, #94, #103, #108, #115
         */

        // this is not correct for this problem, this is a strict root -> leaf solution
        public bool IsPathOfGivenSum(TreeNode n, int sum, List<int> result)
        {
            if (n == null) return false;

            if (n.Left == null && n.Right == null)
            {
                // at leaf node
                if (n.Val == sum)
                {
                    result.Add(n.Val);
                    return true;
                }

                return false;
            }

            if (IsPathOfGivenSum(n.Left, sum - n.Val, result))
            {
                result.Add(n.Val);
                return true;
            }

            if (IsPathOfGivenSum(n.Right, sum - n.Val, result))
            {
                result.Add(n.Val);
                return true;
            }

            return false;
        }
    }
}