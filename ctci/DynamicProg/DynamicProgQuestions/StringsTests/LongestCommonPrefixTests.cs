using System.Collections.Generic;
using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class LongestCommonPrefixTests
    {
        [Test]
        public void ShouldReturnLongestPrefix()
        {
            List<string> input = new List<string> { "abc", "ab", "abbc" };
            LongestCommonPrefix lcp = new LongestCommonPrefix();
            string result = lcp.GetLongestCommonPrefix(input);
            Assert.That(result, Is.EqualTo("ab"));
        }
    }
}