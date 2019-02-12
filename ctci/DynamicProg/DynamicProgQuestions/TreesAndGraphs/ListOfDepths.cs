using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class ListOfDepths
    {
        /*
         * 4.3 List of Depths: Given a binary tree, design an algorithm which creates a linked list of all the nodes
           at each depth (e.g., if you have a tree with depth 0, you'll have 0 linked lists).
           Hints: #107, #123, #735
         */

        public List<List<int>> ListDepths(TreeNode n)
        {
            List<List<int>> outer = new List<List<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(n);

            while (q.Count != 0)
            {
                List<int> i = new List<int>();
                int qCount = q.Count;
                for (int j = 0; j < qCount; j++)
                {
                    TreeNode tn = q.Dequeue();
                    i.Add(tn.Val);
                    if (tn.Left != null) q.Enqueue(tn.Left);
                    if (tn.Right != null) q.Enqueue(tn.Right);
                }

                outer.Add(i);
            }

            return outer;
        }
    }
}