using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class SumStringAndNumberTests
    {
        [TestCase("999", 1, ExpectedResult = "1000")]
        [TestCase("123", 4, ExpectedResult = "127")]
        public string ShouldCorrectlySumStringAndNumber(string str, int num)
        {
            SumStringAndNumber ssn = new SumStringAndNumber();
            string result = ssn.ComputeSum(str, num);
            return result;
        }
    }
}