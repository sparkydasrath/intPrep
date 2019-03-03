using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class CombinationSumTests
    {
        [Test]
        public void ShouldGetList()
        {
            CombinationSum cs = new CombinationSum();
            System.Collections.Generic.List<System.Collections.Generic.List<int>> r = cs.CombinationSumImp(new int[] { 2, 3, 6, 7 }, 7);
            Assert.That(r.Count, Is.EqualTo(2));
        }
    }
}