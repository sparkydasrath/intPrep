using Arrays;
using NUnit.Framework;
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
    }
}