using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Trees.Tests
{
    [TestFixture]
    public class GetHeightOfTreeTests
    {
        [Test]
        public void VerifyGetHeightBottomUp()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            HeightOfTree heightOfTree = new HeightOfTree();

            int height = heightOfTree.GetHeightBottomUpInstance(root);
            Assert.That(height, Is.EqualTo(3));
        }

        [Test]
        public void VerifyGetHeightTopDown()
        {
            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();
            HeightOfTree heightOfTree = new HeightOfTree();

            int height = heightOfTree.GetHeightTopDown(root);
            Assert.That(height, Is.EqualTo(3));
        }
    }
}