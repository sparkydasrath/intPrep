using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class CollapseSequencesTests
    {
        [TestCase("aabaaccaaaaaada", 'a', ExpectedResult = "abaccada")]
        [TestCase("mississssipppi", 's', ExpectedResult = "misisipppi")]
        [TestCase("babbbbebbbxbbbbbb", 'b', ExpectedResult = "babebxb")]
        [TestCase("palo alto", 'o', ExpectedResult = "palo alto")]
        [TestCase("tennessee", 'x', ExpectedResult = "tennessee")]
        [TestCase("", 'x', ExpectedResult = "")]
        public string ShouldCollapseSequence(string s, char c)
        {
            CollapseSequences cs = new CollapseSequences();
            string result = cs.CollapseSequencesDfs(s, c);
            return result;
        }
    }
}