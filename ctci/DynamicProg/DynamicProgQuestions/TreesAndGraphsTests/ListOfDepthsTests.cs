using System.Collections.Generic;
using NUnit.Framework;
using TreesAndGraphs;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class ListOfDepthsTests
    {
        public TreeNode GenerateTree()
        {
            TreeNode n = new TreeNode(1);
            n.Left = new TreeNode(2);
            n.Left.Left = new TreeNode(4);
            n.Left.Right = new TreeNode(5);

            n.Right = new TreeNode(3);
            n.Right.Left = new TreeNode(6);
            n.Right.Right = new TreeNode(7);
            return n;
        }

        [Test]
        public void ShouldPrintListAtEachDepth()
        {
            ListOfDepths lod = new ListOfDepths();
            TreeNode tn = GenerateTree();
            List<List<int>> res = lod.ListDepths(tn);
            Assert.That(res, Is.Not.Null);
        }
    }
}