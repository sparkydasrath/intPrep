using NUnit.Framework;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class RemoveDuplicatesFromSortedArrayTests
    {
        [TestCase(new[] { 1, 2 }, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 4, 4 }, ExpectedResult = new[] { 1, 2, 4, 0 })]
        [TestCase(new[] { 1, 2, 4, 4, 9, 9, 9, 9 }, ExpectedResult = new[] { 1, 2, 4, 9, 0, 0, 0, 0 })]
        public int[] ShouldRemoveDuplicates(int[] nums)
        {
            RemoveDuplicatesFromSortedArray rd = new RemoveDuplicatesFromSortedArray();
            int[] results = rd.RemoveDuplicates(nums);
            return results;
        }
    }
}