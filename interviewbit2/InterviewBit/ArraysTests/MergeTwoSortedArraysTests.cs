using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class MergeTwoSortedArraysTests
    {
        [TestCase(new int[] { }, new[] { 2, 5, 6 }, ExpectedResult = new[] { 2, 5, 6 })]
        [TestCase(null, new[] { 2, 5, 6 }, ExpectedResult = new[] { 2, 5, 6 })]
        [TestCase(null, null, ExpectedResult = new int[] { })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 2, 5, 6 }, ExpectedResult = new[] { 1, 2, 2, 3, 5, 6 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 5, 6 }, ExpectedResult = new[] { 1, 2, 2, 5, 6 })]

        public int[] Merge(int[] nums1, int[] nums2)
        {
            MergeTwoSortedArrays ma = new MergeTwoSortedArrays();
            int[] result = ma.Merge(nums1, nums2);
            return result;
        }
    }
}