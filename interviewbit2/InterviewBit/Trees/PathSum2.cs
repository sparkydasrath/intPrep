using System.Collections.Generic;

namespace Trees
{
    public class PathSum2
    {
        /*113. Path Sum II https://leetcode.com/problems/path-sum-ii/
        Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

        Note: A leaf is a node with no children.

        Example:

        Given the below binary tree and sum = 22,

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1

        Return:

        [
           [5,4,11,2],
           [5,8,4,5]
        ]

         */

        public List<List<int>> PathSumDfs(TreeNode root, int sum)
        {
            List<List<int>> results = new List<List<int>>();
            List<int> paths = new List<int>();
            PathSumDfsHelper(root, sum, results, paths);
            return results;
        }

        public void PathSumDfsHelper(TreeNode root, int sum, List<List<int>> results, List<int> paths)
        {
            if (root == null) return;

            paths.Add(root.Val);
            if (root.Left == null && root.Right == null && root.Val == sum)
            {
                /*
                 *  at a leaf, need to check if the value of the node is equal to sum
                 */
                if (root.Val == sum)
                    results.Add(new List<int>(paths));
                return;
            }

            if (root.Left != null)
            {
                PathSumDfsHelper(root.Left, sum - root.Val, results, paths);
                paths.RemoveAt(paths.Count - 1);
            }

            if (root.Right != null)
            {
                PathSumDfsHelper(root.Right, sum - root.Val, results, paths);
                paths.RemoveAt(paths.Count - 1);
            }
        }

        public List<List<int>> PathSumIterative(TreeNode root, int sum)
        {
            // https://leetcode.com/problems/path-sum-ii/discuss/36695/Java-Solution%3A-iterative-and-recursive
            if (root == null) return null;

            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            TreeNode prev = null;
            int runningSum = 0;

            while (cur != null || stack.Count != 0)
            {
                // walk all the way down the left subtree until you hit the end
                while (cur != null)
                {
                    // push the current node onto the stack
                    stack.Push(cur);
                    // add the node to the path list as a potential contributor to the final path
                    path.Add(cur.Val);
                    // update the running sum
                    runningSum += cur.Val;
                    // keep exploring left subtree
                    cur = cur.Left;
                }

                // at this point we have done all the way down the left side so the last node seen is
                // at the top of the stack
                cur = stack.Peek();

                // see if it has a right child to explore
                if (cur.Right != null && cur.Right != prev)
                {
                    cur = cur.Right;
                    continue;
                }

                // now we hit the end of this path, check if the path so far is valid
                if (cur.Left == null && cur.Right == null && runningSum == sum)
                    results.Add(new List<int>(path));

                // store the current node we explored from
                prev = cur;
                // remove the last node since at this point we can't go any further when this loop
                // runs again, we would explore the right subtree of the node after this popped node
                stack.Pop();
                // since we are backing up one node, need to remove it from the current path list
                path.RemoveAt(path.Count - 1);
                // update the sum - remove the last node's contribution since this path did not give
                // us the required sum
                runningSum -= cur.Val;
                cur = null;
            }

            return results;
        }
    }
}