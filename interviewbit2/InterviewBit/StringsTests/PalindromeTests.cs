using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class PalindromeTests
    {
        [TestCase("madam", ExpectedResult = true)]
        [TestCase("maam", ExpectedResult = true)]
        [TestCase("mamm", ExpectedResult = false)]
        public bool IsPalindrome(string s)
        {
            Palindrome p = new Palindrome();
            bool result = p.IsPalindrome(s);
            return result;
        }
    }
}