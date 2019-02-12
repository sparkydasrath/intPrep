using NUnit.Framework;
using System.Collections.Generic;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class FourSumTests
    {
        [Test]
        public void GetFourSumWithSortAndWindowAndFirstTwoFixed()
        {
            FourSum fs = new FourSum();

            List<IList<int>> results1 = fs.FourSumSortAndWindowAndFirstTwoFixed(new[] { -3, -1, 0, 2, 4, 5 }, 0);
            Assert.That(results1.Count, Is.EqualTo(1));

            List<IList<int>> results2 = fs.FourSumSortAndWindowAndFirstTwoFixed(new[] { 1, 0, -1, 0, -2, 2 }, 0);
            Assert.That(results2.Count, Is.EqualTo(3));
        }
    }
}