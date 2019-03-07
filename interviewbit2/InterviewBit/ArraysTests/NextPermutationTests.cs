using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class NextPermutationTests
    {
        [Test]
        public void ShouldSortToGetNextPermutation()
        {
            int[] nums = { 3, 2, 1 };
            NextPermutation np = new NextPermutation();
            np.NextPerm_TimeoutExceeded(nums);
            int[] expected = { 1, 2, 3 };
            CollectionAssert.AreEqual(nums, expected);
        }

        [Test]
        public void ShouldSwapToGetNextPermutation()
        {
            int[] nums = { 1, 2, 3 };
            NextPermutation np = new NextPermutation();
            np.NextPerm_TimeoutExceeded(nums);
            int[] expected = { 1, 3, 2 };
            CollectionAssert.AreEqual(nums, expected);
        }
    }
}