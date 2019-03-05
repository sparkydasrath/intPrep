using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationInStringTests
    {
        [TestCase("ab", "eidbaooo", ExpectedResult = true)]
        [TestCase("ab", "eidboaoo", ExpectedResult = false)]
        public bool CheckInclusion(string s1, string s2)
        {
            PermutationInString p = new PermutationInString();
            bool result = p.CheckInclusion(s1, s2);
            return result;
        }
    }
}