using NUnit.Framework;
using TreesAndGraphs;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class ArrayPartitionTests
    {
        [Test]
        public void ShouldPartitionEvenCorrectly()
        {
            int[] given = { 1, 2, 3, 4 };
            int[] left = { 1, 2 };
            int[] right = { 4 };
            int root = 3;
            ArrayPartition ap = new ArrayPartition();
            ap.CreatePartitionsFrom(given);
            Assert.That(ap.Root, Is.EqualTo(root));
            Assert.That(ap.Left, Is.EqualTo(left));
            Assert.That(ap.Right, Is.EqualTo(right));
        }

        [Test]
        public void ShouldPartitionOddCorrectly()
        {
            int[] given = { 1, 2, 3, 4, 5 };
            int[] left = { 1, 2 };
            int[] right = { 4, 5 };
            int root = 3;
            ArrayPartition ap = new ArrayPartition();
            ap.CreatePartitionsFrom(given);
            Assert.That(ap.Root, Is.EqualTo(root));
            Assert.That(ap.Left, Is.EqualTo(left));
            Assert.That(ap.Right, Is.EqualTo(right));
        }
    }
}