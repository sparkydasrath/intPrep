using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class DigitsSortedTests
    {
        [TestCase(0, ExpectedResult = true)]
        [TestCase(-5, ExpectedResult = true)]
        [TestCase(2345, ExpectedResult = true)]
        [TestCase(-2345, ExpectedResult = true)]
        [TestCase(4321, ExpectedResult = false)]
        [TestCase(24378, ExpectedResult = false)]
        [TestCase(-33331, ExpectedResult = false)]
        public bool ShouldCheckDigits(int n)
        {
            DigitsSorted ds = new DigitsSorted();
            bool result = ds.DigitsSortedDfs(n);
            return result;
        }
    }
}