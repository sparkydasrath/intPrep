using NUnit.Framework;

namespace Facebook.Tests
{
    [TestFixture]
    public class MinimumWindowSubstringTests
    {
        [Test]
        public void ShouldReturnMinimumWindowSubstring()
        {
            MinimumWindowSubstring m = new MinimumWindowSubstring();
            // string result = m.MinWindow("ADOBECODEBANC", "ABC");
            string result2 = m.MinWindow2("ADOBECODEBANC", "ABC");
            // Assert.That(result, Is.EqualTo("BANC"));
            Assert.That(result2, Is.EqualTo("BANC"));
        }
    }
}