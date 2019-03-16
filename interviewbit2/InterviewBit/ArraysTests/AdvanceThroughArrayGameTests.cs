using Arrays;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ArraysTests
{
    [TestFixture]
    public class AdvanceThroughArrayGameTests
    {
        [TestCase(new[] { 3, 3, 1, 0, 2, 0, 1 }, ExpectedResult = true)]
        public bool ShouldCheckIfCanReachEnd(int[] nums)
        {
            AdvanceThroughArrayGame g = new AdvanceThroughArrayGame();
            bool result = g.CanReachEnd(nums.ToList());
            return result;
        }

        [Test]
        public void ShouldGetMinimumJumpsToGetToEndOfList()
        {
            AdvanceThroughArrayGame a = new AdvanceThroughArrayGame();
            int result = a.MinimumJumpsToGetToEndOfList(new List<int> { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 });
            Assert.That(result, Is.EqualTo(3));
        }
    }
}