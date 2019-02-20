using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void ShouldPermuteWithRepeatedChars()
        {
            Permutations p = new Permutations();
            p.PermuteWithRepeatedCharsBase("aabc");
            Assert.That(p.AllResults.Count, Is.EqualTo(12));
        }
    }
}