using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class LongestSubstringWithAtMostTwoDistinctCharactersTests
    {
        [TestCase("leeeeeeeetcooooooooode", ExpectedResult = 10)]
        [TestCase("eceba", ExpectedResult = 3)]
        [TestCase("aac", ExpectedResult = 3)]
        public int ShouldReturnLongestSubstringWithAtMostTwoDistinctCharacters(string s)
        {
            LongestSubstringWithAtMostTwoDistinctCharacters ls = new LongestSubstringWithAtMostTwoDistinctCharacters();
            int result = ls.LengthOfLongestSubstringTwoDistinct1(s);
            return result;
        }

        [TestCase("leeeeeeeetcooooooooode", ExpectedResult = 10)]
        [TestCase("eceba", ExpectedResult = 3)]
        [TestCase("aac", ExpectedResult = 3)]
        public int ShouldReturnLongestSubstringWithAtMostTwoDistinctCharacters2(string s)
        {
            LongestSubstringWithAtMostTwoDistinctCharacters ls = new LongestSubstringWithAtMostTwoDistinctCharacters();
            int result = ls.LengthOfLongestSubstringTwoDistinct2(s);
            return result;
        }
    }
}