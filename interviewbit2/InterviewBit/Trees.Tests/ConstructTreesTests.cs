using NUnit.Framework;

namespace Trees.Tests
{
    [TestFixture]
    public class ConstructTreesTests
    {
        [Test]
        public void ShouldBuildTreeFromPreOrderAndInOrder()
        {
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };

            ConstructTrees ct = new ConstructTrees();
            TreeNode root = ct.FromPreOrderAndInOrder(preorder, inorder);

            Assert.That(root, Is.Not.Null);
            Assert.That(root.Val, Is.EqualTo(3));
            Assert.That(root.Left.Val, Is.EqualTo(9));
            Assert.That(root.Right.Val, Is.EqualTo(20));
            Assert.That(root.Right.Left.Val, Is.EqualTo(15));
            Assert.That(root.Right.Right.Val, Is.EqualTo(7));
        }
    }
}