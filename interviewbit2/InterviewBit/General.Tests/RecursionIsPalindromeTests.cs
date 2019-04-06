using NUnit.Framework;
using NUnit.Framework.Internal;

namespace General.Tests
{
    [TestFixture]
    public class RecursionIsPalindromeTests
    {
        [TestCase("madam", ExpectedResult = true)]
        [TestCase("maam", ExpectedResult = true)]
        [TestCase("mamm", ExpectedResult = false)]
        public bool IsPalindrome(string s)
        {
            bool result = RecursionIsPalindrome.IsPalindrome(s);
            return result;
        }
    }
}