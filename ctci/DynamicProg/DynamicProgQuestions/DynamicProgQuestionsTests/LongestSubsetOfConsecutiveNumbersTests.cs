using DynamicProgQuestions;
using NUnit.Framework;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class LongestSubsetOfConsecutiveNumbersTests
    {
        [Test]
        public void ShouldReturnLongestSubsetOfConsecutiveNumbers()
        {
            LongestSubsetOfConsecutiveNumbers ls = new LongestSubsetOfConsecutiveNumbers();

            int[] input = { 1, 3, 8, 14, 4, 10, 2, 11 };
            int[] result = ls.GetLargestSubset(input);
            int[] expected = { 1, 2, 3, 4 };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}