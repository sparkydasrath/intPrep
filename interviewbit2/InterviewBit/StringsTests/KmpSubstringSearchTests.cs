using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class KmpSubstringSearchTests
    {
        [TestCase("abcxabcdabcdabcy", "abcdabcy", ExpectedResult = true)]
        [TestCase("abcxabcdabcdabcy", "wxyz", ExpectedResult = false)]
        [TestCase("abxabcabcaby", "abcaby", ExpectedResult = true)]
        public bool ShouldCheckIfSubstringIsPresentInGivenString(string given, string substring)
        {
            KmpSubstringSearch kmp = new KmpSubstringSearch();
            bool result = kmp.KmpSearch(given, substring);
            return result;
        }

        [TestCase("aabaabaaa", ExpectedResult = new[] { 0, 1, 0, 1, 2, 3, 4, 5, 2 })]
        [TestCase("abcdabca", ExpectedResult = new[] { 0, 0, 0, 0, 1, 2, 3, 1 })]
        [TestCase("abcaby", ExpectedResult = new[] { 0, 0, 0, 1, 2, 0 })]
        public int[] VerifyPrefixToSuffixMatchingTruthTable(string str)
        {
            KmpSubstringSearch kmp = new KmpSubstringSearch();
            int[] result = kmp.BuildPrefixToSuffixMatchingArray(str);
            return result;
        }
    }
}