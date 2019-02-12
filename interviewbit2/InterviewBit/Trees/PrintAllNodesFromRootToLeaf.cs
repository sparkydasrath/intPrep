using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    public class PrintAllNodesFromRootToLeaf
    {
        /*
          (vivek) https://www.youtube.com/watch?v=zIkDfgFAg60
          1 .Given a binary tree. Print all the root to leaf paths in the tree.
          2. print out all of its root-to-leaf paths one per line.
         */
        private readonly Stack<int> stack = new Stack<int>();

        public void PrintRootToLeaf(TreeNode root, List<List<int>> results)
        {
            if (root == null) return;

            stack.Push(root.Val);

            if (root.Left == null && root.Right == null)
            {
                int[] arr = stack.ToArray();
                Array.Reverse(arr);
                results.Add(arr.ToList());
                return;
            }

            PrintRootToLeaf(root.Left, results);
            PrintRootToLeaf(root.Right, results);

            stack.Pop();
        }
    }
}