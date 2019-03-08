using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationInStringTests
    {
        [TestCase("ab", "eidbaooo", ExpectedResult = true)]
        [TestCase("ab", "eidboaoo", ExpectedResult = false)]
        [TestCase("adc", "dcda", ExpectedResult = true)]
        [TestCase("hello", "ooolleoooleh", ExpectedResult = false)]
        [TestCase("abc", "bbbca", ExpectedResult = true)]
        public bool CheckInclusion(string s1, string s2)
        {
            PermutationInString p = new PermutationInString();
            bool result = p.CheckInclusion(s1, s2);
            return result;
        }

        [TestCase("ab", "eidbaooo", ExpectedResult = true)]
        [TestCase("ab", "eidboaoo", ExpectedResult = false)]
        public bool CheckInclusionTimeout(string s1, string s2)
        {
            PermutationInString p = new PermutationInString();
            bool result = p.CheckInclusionTimeout(s1, s2);
            return result;
        }
    }
}