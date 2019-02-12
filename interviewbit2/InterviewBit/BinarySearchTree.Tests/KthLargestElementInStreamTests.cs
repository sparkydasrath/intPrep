using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BinarySearchTree.Tests
{
    [TestFixture()]
    public class KthLargestElementInStreamTests
    {
        [Test]
        public void ShouldReturnKthLargest()
        {
            int k = 3;
            int[] nums = { 4, 5, 8, 2 };
            KthLargestElementInStream kthLargest = new KthLargestElementInStream(k, nums);
            int r1 = kthLargest.Add(3);
            Assert.That(r1, Is.EqualTo(4));

            int r2 = kthLargest.Add(5);
            Assert.That(r2, Is.EqualTo(5));
        }
    }
}