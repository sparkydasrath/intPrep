using NUnit.Framework;
using System.Collections.Generic;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class ThreeSumTests
    {
        [Test]
        public void GetThreeSumWithSortAndWindow()
        {
            ThreeSum ts = new ThreeSum();
            List<IList<int>> results = ts.ThreeSum1(new[] { -1, 0, 1, 2, -1, -4 });
            List<List<int>> expected = new List<List<int>> { new List<int> { -1, 0, 1 }, new List<int> { -1, -1, 2 } };
            // CollectionAssert.AreEqual(expected, results);
            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetThreeSumWithWindowOnly()
        {
            ThreeSum ts = new ThreeSum();
            List<IList<int>> results = ts.ThreeSumWithSorting(new[] { -1, 0, 1, 2, -1, -4 });
            List<List<int>> expected = new List<List<int>> { new List<int> { -1, 0, 1 }, new List<int> { -1, -1, 2 } };
            // CollectionAssert.AreEqual(expected, results);
            Assert.That(results.Count, Is.EqualTo(2));
        }
    }
}