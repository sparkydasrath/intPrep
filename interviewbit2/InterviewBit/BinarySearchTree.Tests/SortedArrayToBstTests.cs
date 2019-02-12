using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class SortedArrayToBstTests
    {
        [Test]
        public void ShouldConstructHeightBalancedBst()
        {
            SortedArrayToBst a2bst = new SortedArrayToBst();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            TreeNode root = a2bst.GetBstFromSortedArray(nums);
            Assert.That(root.Val, Is.EqualTo(5));
            Assert.That(root.Left.Val, Is.EqualTo(2));
            Assert.That(root.Right.Val, Is.EqualTo(7));
        }
    }
}