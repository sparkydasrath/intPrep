using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class EditDistanceTests
    {
        [TestCase("cat", "dog", ExpectedResult = false)]
        [TestCase("cat", "cast", ExpectedResult = true)]
        [TestCase("cat", "at", ExpectedResult = true)]
        [TestCase("cat", "act", ExpectedResult = false)]
        [TestCase("c", "c", ExpectedResult = false)]
        [TestCase("a", "", ExpectedResult = true)]
        public bool VerifyThatStringsAreOneEditDistanceApart(string s1, string s2)
        {
            EditDistance ed = new EditDistance();
            bool result = ed.IsOneEditDistance(s1, s2);
            return result;
        }
    }
}