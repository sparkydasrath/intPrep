using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class CombinationsTests
    {
        [Test]
        public void ShouldCombineWithRepeatedChars()
        {
            Combinations c = new Combinations();
            c.CombineWithRepeatedCharsBase("aabc");
            Assert.That(c.AllResults.Count, Is.EqualTo(12));
        }
    }
}