using arrays01;
using NUnit.Framework;

namespace Arrays01Tests
{
    [TestFixture]
    public class DominantIndexTests
    {
        [Test]
        public void GetDominantIndex()
        {
            DominantIndex di = new DominantIndex();
            int[] nums = { 0, 0, 0, 1 };
            int result = di.GetDominantIndex(nums);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ShouldReturnCorrectSum()
        {
            DominantIndex di = new DominantIndex();
            int[] nums = { 1, 3, 9 };
            int[] result = di.PlusOne(nums);
            int[] expected = { 1, 4, 0 };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnLargerArray()
        {
            DominantIndex di = new DominantIndex();
            int[] nums = { 8, 9, 9, 9 };
            int[] result = di.PlusOne(nums);
            int[] expected = { 9, 0, 0, 0 };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}