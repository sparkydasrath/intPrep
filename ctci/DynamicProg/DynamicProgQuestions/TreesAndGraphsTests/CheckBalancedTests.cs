using NUnit.Framework;
using TreesAndGraphs;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class CheckBalancedTests
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
        public void ShouldReturnTrueIfBalanced()
        {
            CheckBalanced cb = new CheckBalanced();
            TreeNode test = GenerateTree();
            bool res = cb.IsBalanced(test);
            Assert.That(res, Is.True);
        }
    }
}