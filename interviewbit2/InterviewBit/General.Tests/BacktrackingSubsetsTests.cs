using NUnit.Framework;
using System.Collections.Generic;

namespace General.Tests
{
    [TestFixture]
    public class BacktrackingSubsetsTests
    {
        [Test]
        public void ShouldPrintAllSublistsWithoutRepetition()
        {
            BacktrackingSubsets bs = new BacktrackingSubsets();

            List<List<int>> results = bs.Subsets(new int[] { 1, 2, 3 });
            List<List<int>> exected = new List<List<int>>
            {
                new List<int>{},
                new List<int>{3},
                new List<int>{2},
                new List<int>{2, 3},
                new List<int>{1},
                new List<int>{1, 3},
                new List<int>{1, 2},
                new List<int>{1, 2, 3},
            };

            CollectionAssert.AreEqual(results, exected);
        }
    }
}