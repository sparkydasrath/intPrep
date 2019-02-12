using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class DecodeStringsTests
    {
        [TestCase("3[a]2[bc]", ExpectedResult = "aaabcbc")]
        /*[TestCase("3[a2[c]]", ExpectedResult = "accaccacc")]
        [TestCase("2[abc]3[cd]ef", ExpectedResult = "abcabccdcdcdef")]*/
        public string ShouldDecodeStringRecursive(string s)
        {
            DecodeStrings ds = new DecodeStrings();
            string recResult = ds.DecodeStringDfs(s);
            return recResult;
        }
    }
}