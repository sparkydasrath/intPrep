using System.Collections.Generic;
using NUnit.Framework;
using TreesAndGraphs;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class MinimalTreeTests
    {
        public TreeNode BuildTree()
        {
            TreeNode n = new TreeNode(7);
            n.Left = new TreeNode(4);
            n.Left.Left = new TreeNode(2);
            n.Left.Right = new TreeNode(5);

            n.Right = new TreeNode(11);
            n.Right.Left = new TreeNode(9);
            n.Right.Right = new TreeNode(13);
            n.Right.Right.Left = new TreeNode(12);

            return n;
        }

        public int[] GetArray(int number)
        {
            List<int> i = new List<int>();
            for (int j = 0; j < number; j++)
            {
                i.Add(j + 1);
            }

            return i.ToArray();
        }

        [Test]
        public void ShouldDoBinarySearchTreeBuilding()
        {
            TreeNode test = BuildTree();
            int[] given = GetArray(13);
            MinimalTree mt = new MinimalTree(given);
            TreeNode tn = mt.CreateMinTree(given);
        }
    }
}