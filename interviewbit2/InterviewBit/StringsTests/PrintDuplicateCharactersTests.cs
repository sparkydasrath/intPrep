using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class PrintDuplicateCharactersTests
    {
        [TestCase(null, ExpectedResult = "")]
        [TestCase("a", ExpectedResult = "")]
        [TestCase("aabc", ExpectedResult = "a")]
        [TestCase("aabbbcdeee", ExpectedResult = "abe")]
        public string GetDuplicated(string s)
        {
            PrintDuplicateCharacters pdc = new PrintDuplicateCharacters();
            string results = pdc.GetDuplicates(s);
            return results;
        }
    }
}