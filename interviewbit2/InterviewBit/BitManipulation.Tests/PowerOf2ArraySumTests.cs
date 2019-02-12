using NUnit.Framework;

namespace BitManipulation.Tests
{
    [TestFixture]
    public class PowerOf2ArraySumTests
    {
        [TestCase(new[] { 2, 1, 4, 5 }, ExpectedResult = 4)]
        [TestCase(new[] { 1, 2, 3, 2 }, ExpectedResult = 3)]
        public int GetNextPowerOf2(int[] arr)
        {
            PowerOf2ArraySum p2 = new PowerOf2ArraySum();
            return p2.NextPowerOf2(arr);
        }
    }
}