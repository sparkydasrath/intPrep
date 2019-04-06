using NUnit.Framework;

namespace InterviewTests.Tests
{
    [TestFixture]
    public class AnnalyTests
    {
        [TestCase(new[] { 1.50f, 1.50f, 1.50f, 1.50f, 1.50f }, ExpectedResult = 3)]
        public int EfficientJanitor(float[] weights)
        {
            int result = Annaly.EfficientJanitorHelper(weights);
            return result;
        }

        [TestCase(new[] { 7, 2, 3, 10, 2, 4, 8, 1 }, ExpectedResult = 8)]
        [TestCase(new[] { 5, 10, 8, 7, 6, 5 }, ExpectedResult = 5)]
        [TestCase(new[] { 6, 7, 9, 5, 6, 3, 2 }, ExpectedResult = 2)]
        public int MaxDifference(int[] nums)
        {
            int result = Annaly.MaxDifferenceInner(nums);
            return result;
        }

        [TestCase(new[] { 3, 1, 2, 3 }, new int[] { 3, 2, 1, 3 }, "Even", ExpectedResult = "Andrea")]
        public string Winner(int[] a, int[] m, string s)
        {
            string result = Annaly.WinnerHelper(a, m, s);
            return result;
        }
    }
}