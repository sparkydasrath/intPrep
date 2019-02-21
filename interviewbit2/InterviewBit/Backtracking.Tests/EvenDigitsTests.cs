using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Backtracking.Tests
{
    [TestFixture]
    public class EvenDigitsTests
    {
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(23, ExpectedResult = 1)]
        [TestCase(232, ExpectedResult = 2)]
        [TestCase(8342116, ExpectedResult = 4)]
        [TestCase(35179, ExpectedResult = 0)]
        public int CountEvenDigts(int n)
        {
            EvenDigits ed = new EvenDigits();
            int result = ed.CountNumberOfEvenDigits(n);
            return result;
        }

        [TestCase(2, ExpectedResult = 2)]
        [TestCase(23, ExpectedResult = 2)]
        [TestCase(232, ExpectedResult = 22)]
        [TestCase(8342116, ExpectedResult = 8426)]
        [TestCase(35179, ExpectedResult = 0)]
        public int EvenDigitsDfs(int n)
        {
            EvenDigits ed = new EvenDigits();
            int result = ed.EvenDigitsDfs(n);
            return result;
        }
    }
}