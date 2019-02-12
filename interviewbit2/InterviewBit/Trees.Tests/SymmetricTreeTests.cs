using NUnit.Framework;
using System.Collections.Generic;

namespace Trees.Tests
{
    [TestFixture]
    public class SymmetricTreeTests
    {
        [Test]
        public void VerifyConvertToMirror()
        {
            TreeNode root = BuildTreeToMirror();
            SymmetryAndMirrorTrees st = new SymmetryAndMirrorTrees();
            TreeNode result = st.ConvertToMirror(root);

            TreeTraversal tt = new TreeTraversal();
            List<List<int>> levelOrder = tt.LevelOrderIterative(root);

            Assert.That(levelOrder, Is.Not.Null);
            Assert.That(result.Left.Val, Is.EqualTo(3));
            Assert.That(result.Right.Val, Is.EqualTo(2));

            Assert.That(result.Left.Left.Val, Is.EqualTo(7));
            Assert.That(result.Right.Right.Val, Is.EqualTo(4));
        }

        [Test]
        public void VerifySymmetricTree()
        {
            TreeNode root = BuildTree();
            SymmetryAndMirrorTrees st = new SymmetryAndMirrorTrees();
            bool result = st.IsSymmetric(root);
            Assert.IsTrue(result);
        }

        private TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(1);

            TreeNode left = new TreeNode(2)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(4)
            };

            TreeNode right = new TreeNode(2)
            {
                Left = new TreeNode(4),
                Right = new TreeNode(3)
            };

            root.Left = left;
            root.Right = right;

            return root;
        }

        private TreeNode BuildTreeToMirror()
        {
            TreeNode root = new TreeNode(1);

            TreeNode left = new TreeNode(2)
            {
                Left = new TreeNode(4),
                Right = new TreeNode(5)
            };

            TreeNode right = new TreeNode(3)
            {
                Left = new TreeNode(6),
                Right = new TreeNode(7)
            };

            root.Left = left;
            root.Right = right;

            return root;
        }
    }
}