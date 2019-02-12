using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BstOperationsTests
    {
        public TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(5)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(6)
            };
            return root;
        }

        [Test]
        public void ShouldDeleteCorrectly()
        {
            TreeNode root = BuildTree();
            BstOperations bstOperations = new BstOperations();
            TreeNode result = bstOperations.Delete(root, 5);
            Assert.That(result.Val, Is.EqualTo(6));
        }

        [Test]
        public void ShouldInsertCorrectly()
        {
            BstOperations bstOperations = new BstOperations();
            // TreeNode root = BuildTree();

            TreeNode root = bstOperations.Insert(null, 5);
            Assert.That(root.Val, Is.EqualTo(5));

            TreeNode two = bstOperations.Insert(root, 2);
            Assert.That(root.Left.Val, Is.EqualTo(2));

            TreeNode six = bstOperations.Insert(root, 6);
            Assert.That(root.Right.Val, Is.EqualTo(6));

            TreeNode one = bstOperations.Insert(root, 1);
            Assert.That(root.Left.Left.Val, Is.EqualTo(1));

            TreeNode seven = bstOperations.Insert(root, 7);
            Assert.That(root.Right.Right.Val, Is.EqualTo(7));
        }

        [Test]
        public void ShouldSearchCorrectly()
        {
            TreeNode root = BuildTree();
            BstOperations bstOperations = new BstOperations();
            TreeNode result = bstOperations.Search(root, 5);
            Assert.That(result.Val, Is.EqualTo(5));
        }
    }
}