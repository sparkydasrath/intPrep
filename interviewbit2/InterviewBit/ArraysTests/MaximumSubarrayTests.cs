using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class MaximumSubarrayTests
    {
        [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, ExpectedResult = 6)]
        public int MaxSubarrayBigOn2(int[] nums)
        {
            MaximumSumSubarray ms = new MaximumSumSubarray();
            int result = ms.MaxSubArrayBigOn2(nums);
            return result;
        }

        [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, ExpectedResult = 6)]
        public int MaxSubarrayBigOnv1(int[] nums)
        {
            MaximumSumSubarray ms = new MaximumSumSubarray();
            int result = ms.MaxSubArrayBigOnv1(nums);
            return result;
        }

        [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, ExpectedResult = 6)]
        public int MaxSubarrayBigOnv2(int[] nums)
        {
            MaximumSumSubarray ms = new MaximumSumSubarray();
            int result = ms.MaxSubArrayBigOnv2(nums);
            return result;
        }
    }
}