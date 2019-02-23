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

        [Test]
        public void ShouldGetAllSubsets()
        {
            Combinations c = new Combinations();
            System.Collections.Generic.List<System.Collections.Generic.List<int>> res = c.SubsetsDfs(new int[] { 1, 2, 3 });
            Assert.That(res.Count, Is.EqualTo(6));
        }
    }
}