using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class ContainsDuplicateTests
    {
        [TestCase(new[] { 1, 2, 3, 1 }, 3, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 1, 1 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 99, 99 }, 2, ExpectedResult = true)]
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            ContainsDuplicateII c = new ContainsDuplicateII();
            bool result = c.ContainsNearbyDuplicate(nums, k);
            return result;
        }
    }
}