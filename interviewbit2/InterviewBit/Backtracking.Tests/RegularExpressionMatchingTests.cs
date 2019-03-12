using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class RegularExpressionMatchingTests
    {
        [TestCase("aa", "a", ExpectedResult = false)/*Explanation: "a" does not match the entire
        string "aa".*/]
        [TestCase("aa", "a*", ExpectedResult = true)/*Explanation: '*' means zero or more of the
        preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".*/]
        [TestCase("ab", ".*", ExpectedResult = true)/*Explanation: ".*" means "zero or more (*) of
        any character (.)"*/]
        [TestCase("aab", "c*a*b", ExpectedResult = true)/*Explanation: c can
        be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".*/]
        [TestCase("mississippi", "mis*is*p*.", ExpectedResult = false)]
        public bool IsMatch(string s, string p)
        {
            RegularExpressionMatching re = new RegularExpressionMatching();
            bool result = re.IsMatch(s, p);
            return result;
        }

        [TestCase("aa", "a", ExpectedResult = false)/*Explanation: "a" does not match the entire string "aa".*/]
        [TestCase("aa", "a*", ExpectedResult = true)/*Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".*/]
        [TestCase("ab", ".*", ExpectedResult = true)/*Explanation: ".*" means "zero or more (*) of any character (.)"*/]
        [TestCase("aab", "c*a*b", ExpectedResult = true)/*Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".*/]
        [TestCase("mississippi", "mis*is*p*.", ExpectedResult = false)]
        public bool IsMatchDp(string s, string p)
        {
            RegularExpressionMatching re = new RegularExpressionMatching();
            bool result = re.IsMatchDp(s, p);
            return result;
        }
    }
}