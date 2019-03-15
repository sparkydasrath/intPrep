using NUnit.Framework;

namespace Arrays.Tests
{
    [TestFixture]
    public class DutchNationalFlagTests
    {
        [Test]
        public void ShouldPartition1()
        {
            int[] nums = { 0, 1, 2, 0, 2, 1, 1 };
            int[] expected = { 0, 1, 0, 1, 1, 2, 2 };
            DutchNationalFlag df = new DutchNationalFlag();
            int[] result = df.SortDnf1(nums, 2);
            CollectionAssert.AreEqual(result, expected);
        }

        [Test]
        public void ShouldPartition2()
        {
            int[] nums = { 0, 1, 2, 0, 2, 1, 1 };
            int[] expected = { 0, 1, 0, 1, 1, 2, 2 };
            DutchNationalFlag df = new DutchNationalFlag();
            int[] result = df.SortDnf2(nums, 2);
            CollectionAssert.AreEqual(result, expected);
        }
    }
}