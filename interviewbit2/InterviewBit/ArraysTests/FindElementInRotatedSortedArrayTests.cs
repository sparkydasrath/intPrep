using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class FindElementInRotatedSortedArrayTests
    {
        [Test]
        public void ShouldFindPivotIndexInGivenSortedAndRotatedArray()
        {
            FindElementInRotatedSortedArray sra = new FindElementInRotatedSortedArray();
            int[] n = { 9, 12, 15, 17, 25, 28, 32, 37, 3, 5, 7, 8 };
            int pivotIndex = sra.FindPivotIndex(0, n.Length - 1, n);
            Assert.That(pivotIndex, Is.EqualTo(7));
        }
    }
}