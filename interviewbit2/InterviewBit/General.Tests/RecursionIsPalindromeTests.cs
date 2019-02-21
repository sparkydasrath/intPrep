using NUnit.Framework;
using NUnit.Framework.Internal;

namespace General.Tests
{
    [TestFixture]
    public class RecursionIsPalindromeTests
    {
        [TestCase("madam", ExpectedResult = true)]
        public bool IsPalindrome(string s)
        {
            bool result = RecursionIsPalindrome.IsPalindrome(s);
            return result;
        }
    }
}