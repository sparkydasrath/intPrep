using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace Trees.Tests
{
    [TestFixture()]
    public class TreeTraversalTests
    {
        [Test]
        public void VerifyBottomView()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.BottomView(root);

            CollectionAssert.AreEqual(result, new List<int> { 15, 16, 0, 18, 9 });
        }

        [Test]
        public void VerifyInOrderIterative1()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.InOrderIterative2(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(15));
            Assert.That(result[8], Is.EqualTo(9));
        }

        [Test]
        public void VerifyInOrderIterative2()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.InOrderIterative1(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(15));
            Assert.That(result[8], Is.EqualTo(9));
        }

        [Test]
        public void VerifyInOrderRecursive()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.InOrderRecursive(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(15));
            Assert.That(result[8], Is.EqualTo(9));
        }

        [Test]
        public void VerifyLevelOrderIterative()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<List<int>> result = tt.LevelOrderIterative(root);
            Assert.That(result.Count, Is.EqualTo(4));
            CollectionAssert.AreEqual(result[0], new List<int> { 10 });
            CollectionAssert.AreEqual(result[1], new List<int> { 11, -20 });
            CollectionAssert.AreEqual(result[2], new List<int> { 15, 12, 0, 9 });
            CollectionAssert.AreEqual(result[3], new List<int> { 16, 18 });
        }

        [Test]
        public void VerifyPostOrderIterative1()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.PostOrderIterative(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(15));
            Assert.That(result[8], Is.EqualTo(10));
        }

        [Test]
        public void VerifyPostOrderRecursive()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.PostOrderRecursive(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(15));
            Assert.That(result[8], Is.EqualTo(10));
        }

        [Test]
        public void VerifyPreOrderIterative()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.PreOrderIterative(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(10));
            Assert.That(result[8], Is.EqualTo(9));
        }

        [Test]
        public void VerifyPreOrderRecursive()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.PreOrderRecursive(root);
            Assert.That(result.Count, Is.EqualTo(9));
            Assert.That(result[0], Is.EqualTo(10));
            Assert.That(result[8], Is.EqualTo(9));
        }

        [Test]
        public void VerifyTopView()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<int> result = tt.TopView(root);

            CollectionAssert.AreEqual(result, new List<int> { 15, 11, 10, -20, 9 });
        }

        [Test]
        public void VerifyVerticalOrderRecursive()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            TreeTraversal tt = new TreeTraversal();

            List<List<int>> result = tt.VerticalOrder(root);

            CollectionAssert.AreEqual(result[0], new List<int> { 15 });
            CollectionAssert.AreEqual(result[1], new List<int> { 11, 16 });
            CollectionAssert.AreEqual(result[2], new List<int> { 10, 12, 0 });
        }
    }
}