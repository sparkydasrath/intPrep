using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class LongestPalindromicSubstringTests
    {
        [TestCase("aacbcaa", ExpectedResult = "aacbcaa")]
        [TestCase("bb", ExpectedResult = "bb")]
        [TestCase("abcdefedmabzy", ExpectedResult = "defed")]
        [TestCase("222020221", ExpectedResult = "2202022")]
        [TestCase("222020221", ExpectedResult = "2202022")]
        public string GetPalindromicSubstring(string s)
        {
            LongestPalindromicSubstring lps = new LongestPalindromicSubstring();
            return lps.GetLongestPalindromicSubstring(s);
        }
    }
}