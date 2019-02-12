using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DpLongestCommonSubsequenceTests
    {
        [TestCase("acbcf", "abcdaf", ExpectedResult = 4)]
        public int ShouldGetTheLongestCommonSubsequence(string s1, string s2)
        {
            DpLongestCommonSubsequence lcs = new DpLongestCommonSubsequence();
            int result = lcs.LongestCommonSubsequence(s1, s2);
            return result;
        }
    }
}