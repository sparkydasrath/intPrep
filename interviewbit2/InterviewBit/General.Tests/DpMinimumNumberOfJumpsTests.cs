using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DpMinimumNumberOfJumpsTests
    {
        [TestCase(new[] { 2, 1, 3, 2, 3, 4, 5, 1, 2, 8 }, ExpectedResult = 3)]
        public int GetMinimumNumberOfJumps(int[] arr)
        {
            DpMinimumNumberOfJumps minimumNumberOfJumps = new DpMinimumNumberOfJumps();
            int result = minimumNumberOfJumps.MinimumNumberOfJumps(arr);
            return result;
        }
    }
}