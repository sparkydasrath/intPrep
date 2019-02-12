using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class MaxConsecutiveOnesTests
    {
        [TestCase(new int[] { 1, 1, 0, 1, 1, 1 }, ExpectedResult = 3)]
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            MaxConsecutiveOnes m = new MaxConsecutiveOnes();
            int max = m.FindMaxConsecutiveOnes(nums);
            return max;
        }
    }
}