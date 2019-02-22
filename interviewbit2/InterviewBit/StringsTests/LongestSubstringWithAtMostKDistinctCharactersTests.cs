using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class LongestSubstringWithAtMostKDistinctCharactersTests
    {
        [TestCase("leeeeeeeetcooooooooode", ExpectedResult = 10)]
        [TestCase("eceba", ExpectedResult = 3)]
        [TestCase("aac", ExpectedResult = 3)]
        public int ShouldReturnLongestSubstringWithAtMostTwoDistinctCharacters(string s)
        {
            LongestSubstringWithAtMostKDistinctCharacters ls = new LongestSubstringWithAtMostKDistinctCharacters();
            int result = ls.LengthOfLongestSubstringKDistinct(s, 2);
            return result;
        }
    }
}