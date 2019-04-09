using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class MedianOfTwoSortedArraysTests
    {
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, ExpectedResult = 2.5d)]
        public double FindMedian(int[] nums1, int[] nums2)
        {
            MedianOfTwoSortedArrays m = new MedianOfTwoSortedArrays();
            double result = m.FindMedianSortedArrays(nums1, nums2);
            return result;
        }
    }
}