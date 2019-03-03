using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Trees.Tests
{
    [TestFixture]
    public class ConstructBtFromPreorderAndInorderTests
    {
        [Test]
        public void ShouldConstructTree()
        {
            ConstructBtFromPreorderAndInorder c = new ConstructBtFromPreorderAndInorder();
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };
            TreeNode n = c.BuildTree(preorder, inorder);
            Assert.That(n, Is.Not.Null);
            Assert.That(n.Left.Val, Is.EqualTo(9));
            Assert.That(n.Right.Val, Is.EqualTo(20));
        }
    }
}