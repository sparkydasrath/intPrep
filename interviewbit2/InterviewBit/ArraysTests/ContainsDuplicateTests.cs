using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class ContainsDuplicateTests
    {
        [TestCase(new[] { 1, 2, 3, 1, 3, 6, 6 }, ExpectedResult = "136")]
        public string ContainsDuplicateConstantSpace(int[] nums)
        {
            ContainsDuplicateIII c = new ContainsDuplicateIII();
            string result = c.ContainsDuplicateConstantSpace(nums);
            return result;
        }

        [TestCase(new[] { 1, 2, 3, 1 }, 3, ExpectedResult = true)]
        [TestCase(new[] { 1, 0, 1, 1 }, 1, ExpectedResult = true)]
        [TestCase(new[] { 99, 99 }, 2, ExpectedResult = true)]
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            ContainsDuplicateII c = new ContainsDuplicateII();
            bool result = c.ContainsNearbyDuplicate(nums, k);
            return result;
        }

        [TestCase(new[] { 1, 2, 3, 4, 4 }, ExpectedResult = 4)]
        [TestCase(new[] { 40, 50, 60, 60, 60, 70, 80, 90 }, ExpectedResult = 3)]
        public int FindRepeatingElement(int[] nums)
        {
            ContainsDuplicateIV c = new ContainsDuplicateIV();
            int result = c.FindSecondDuplicate(nums, 0, nums.Length - 1);
            return result;
        }

        [TestCase(new[] { 1, 2, 3, 4, 4 }, ExpectedResult = 3)]
        public int SearchDupes(int[] nums)
        {
            ContainsDuplicateIV c = new ContainsDuplicateIV();
            int result = c.SearchDupes(nums, 4);
            return result;
        }

        [TestCase(new[] { 1, 2, 3, 4, 4 }, ExpectedResult = 4)]
        public int SearchDupes1(int[] nums)
        {
            ContainsDuplicateIV c = new ContainsDuplicateIV();
            int result = c.FindFirstOrLastRepeatingElement(nums, 4, false);
            return result;
        }
    }
}