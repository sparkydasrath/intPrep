using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BstIteratorTests
    {
        [Test]
        public void ShouldIterateTreeInCorrectOrder()
        {
            TreeNode root = BuildTree();
            BstIterator bstIterator = new BstIterator(root);
            int next1 = bstIterator.Next();
            Assert.That(next1, Is.EqualTo(3));
            int next2 = bstIterator.Next();
            Assert.That(next2, Is.EqualTo(7));
            int next3 = bstIterator.Next();
            Assert.That(next3, Is.EqualTo(9));
        }

        private TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(7)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(15)
                {
                    Left = new TreeNode(9),
                    Right = new TreeNode(20)
                }
            };
            return root;
        }
    }
}