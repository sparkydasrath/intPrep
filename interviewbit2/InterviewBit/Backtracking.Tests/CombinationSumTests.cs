using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class CombinationSumTests
    {
        [Test]
        public void GetCombinationSum1()
        {
            CombinationSum cs = new CombinationSum();
            IList<IList<int>> r = cs.CombinationSum1(new int[] { 2, 3, 6, 7 }, 7);
            Assert.That(r.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetCombinationSum3()
        {
            CombinationSum cs = new CombinationSum();
            IList<IList<int>> r = cs.CombinationSum3(3, 9);
            Assert.That(r.Count, Is.EqualTo(3));
        }
    }
}