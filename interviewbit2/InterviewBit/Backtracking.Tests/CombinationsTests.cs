using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class CombinationsTests
    {
        [Test]
        public void ShouldCombine2()
        {
            Combinations c = new Combinations();
            IList<IList<int>> results = c.Combine(4, 2);
            Assert.That(results.Count, Is.EqualTo(6));
        }

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
            IList<IList<int>> res = c.Subsets(new[] { 1, 2, 3 });
            /*
             Output:
                [
                  [3],
                  [1],
                  [2],
                  [1,2,3],
                  [1,3],
                  [2,3],
                  [1,2],
                  []
                ]
             */
            Assert.That(res.Count, Is.EqualTo(8));
        }

        [Test]
        public void ShouldGetAllSubsetsWithDup()
        {
            Combinations c = new Combinations();
            IList<IList<int>> res = c.SubsetsWithDup(new[] { 1, 2, 2 });
            /*
             * Output:
            [
              [2],
              [1],
              [1,2,2],
              [2,2],
              [1,2],
              []
            ]
             */
            Assert.That(res.Count, Is.EqualTo(6));
        }
    }
}