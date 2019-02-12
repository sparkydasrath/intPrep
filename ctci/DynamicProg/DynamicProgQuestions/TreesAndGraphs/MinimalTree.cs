using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class ArrayPartition
    {
        private int rootIndex;
        public int[] Left { get; set; }
        public int[] Right { get; set; }
        public int Root { get; set; }

        public void CreatePartitionsFrom(int[] given)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            if (given.Length % 2 == 0)
            {
                // even
                rootIndex = given.Length / 2;
                Root = given[given.Length / 2];

                for (int i = 0; i < rootIndex; i++)
                {
                    left.Add(given[i]);
                }

                Left = left.ToArray();

                for (int i = rootIndex + 1; i < given.Length; i++)
                {
                    right.Add(given[i]);
                }

                Right = right.ToArray();
            }
            else
            {
                rootIndex = (int)Math.Ceiling(given.Length / 2.0);
                Root = given[(int)Math.Ceiling(given.Length / 2.0) - 1];

                for (int i = 0; i < rootIndex - 1; i++)
                {
                    left.Add(given[i]);
                }

                Left = left.ToArray();

                for (int i = rootIndex; i < given.Length; i++)
                {
                    right.Add(given[i]);
                }

                Right = right.ToArray();
            }
        }
    }

    public class MinimalTree
    {
        private readonly int[] given;
        /*
         * 4.2 Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an algorithm
           to create a binary search tree with minimal height.
           Hints: #19, #73, #176
         */

        public MinimalTree(int[] given)
        {
            this.given = given;
            Ap = new ArrayPartition();
            Ap.CreatePartitionsFrom(given);
            Root = new TreeNode(Ap.Root);
        }

        public ArrayPartition Ap { get; }
        public TreeNode Root { get; }

        public void BuildTree(TreeNode node, int[] left, int[] right)
        {
            if (left.Length == 0 && right.Length == 0) return;

            if (node.Left == null)
            {
                ArrayPartition apl = new ArrayPartition();
                apl.CreatePartitionsFrom(left);
                TreeNode n = new TreeNode(apl.Root);
                node.Left = new TreeNode(apl.Root);
                BuildTree(node.Left, apl.Left, apl.Right);
            }

            if (node.Right == null)
            {
                ArrayPartition apr = new ArrayPartition();
                apr.CreatePartitionsFrom(right);
                node.Right = new TreeNode(apr.Root);
                BuildTree(node.Right, apr.Left, apr.Right);
            }
        }

        public TreeNode CreateMinTree(int[] a) => CreateMinTree(a, 0, a.Length - 1);

        private TreeNode CreateMinTree(int[] a, int start, int end)
        {
            if (end < start) return null;
            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(a[mid])
            {
                Left = CreateMinTree(a, 0, mid - 1),
                Right = CreateMinTree(a, mid + 1, end)
            };

            return n;
        }
    }
}