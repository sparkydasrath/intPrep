using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class RepeatedStringMatchTests
    {
        [TestCase("abcd", "cdabcdab", ExpectedResult = 3)]
        [TestCase("a", "aa", ExpectedResult = 2)]
        [TestCase("abc", "cabcabca", ExpectedResult = 4)]
        [TestCase("abcabcabcabc", "abac", ExpectedResult = -1)]
        public int GetRepeatedStringMatch(string a, string b)
        {
            RepeatedStringMatch rs = new RepeatedStringMatch();
            int count = rs.RepeatedStringMatchProblem(a, b);
            return count;
        }
    }
}