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

        [Test]
        public void ShouldPermuteWithVisitedArray()
        {
            Permutations p = new Permutations();
            System.Collections.Generic.List<System.Collections.Generic.List<int>> result = p.PermuteWithVisitedArrayDfs(new int[] { 1, 2, 3 });
            Assert.That(result.Count, Is.EqualTo(6));
        }
    }
}