using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void ShouldPermute2()
        {
            Permute2 p2 = new Permute2();
            IList<IList<int>> results = p2.Permute(new[] { 1, 2, 3 });
            Assert.That(results.Count, Is.Not.Zero);
        }

        [Test]
        public void ShouldPermuteUnique()
        {
            Permutations p = new Permutations();
            IList<IList<int>> results = p.PermuteUnique(new[] { 1, 1, 2 });
            Assert.That(results.Count, Is.EqualTo(3));
        }

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
            IList<IList<int>> result = p.PermuteWithVisitedArrayDfs(new[] { 1, 2, 3, 4 });
            Assert.That(result.Count, Is.EqualTo(24));
        }
    }
}