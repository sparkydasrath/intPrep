using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class ValidParenthesesTests
    {
        [TestCase("()", ExpectedResult = true)]
        [TestCase("]", ExpectedResult = false)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([)]", ExpectedResult = false)]
        public bool CheckIfValid(string s)
        {
            ValidParentheses vp = new ValidParentheses();
            bool result = vp.IsValid(s);
            return result;
        }
    }
}