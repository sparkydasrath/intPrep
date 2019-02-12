using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class StringToIntegerTests
    {
        [TestCase("123", ExpectedResult = 123)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase("-42", ExpectedResult = -42)]
        [TestCase("   -42", ExpectedResult = -42)]
        [TestCase("+1", ExpectedResult = 1)]
        [TestCase("words and 987", ExpectedResult = 0)]
        [TestCase("4193 with words", ExpectedResult = 4193)]
        [TestCase("-91283472332", ExpectedResult = -2147483648)]
        [TestCase("3.14159", ExpectedResult = 3)]
        public int ConvertStringToInteger(string s)
        {
            StringToInteger atoi = new StringToInteger();
            int result = atoi.ConvertStringToInteger(s);
            return result;
        }
    }
}