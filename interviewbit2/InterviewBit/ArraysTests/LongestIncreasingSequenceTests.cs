using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class LongestIncreasingSequenceTests
    {
        [Test]
        public void ShouldReturnTheLengthOfTheLongestIncreasingSubsequence()
        {
            LongestIncreasingSequence lis = new LongestIncreasingSequence();
            int[] values = { 10, 9, 2, 5, 3, 7, 101, 18 };
            int result = lis.GetLongestIncreasingSequence(values);
            Assert.That(result, Is.EqualTo(4));
        }
    }
}