using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class RoatateArrayTests
    {
        [Test]
        public void ShouldReturnArrayWhenRotatedArrayLengthTimes()
        {
            RoatateArray ra = new RoatateArray();
            int[] array = { 1, 2, 3, 4, 5 };
            int rotation = 5;
            int[] expectedResult = { 1, 2, 3, 4, 5 };
            int[] result = ra.Rotate(array, rotation);
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void ShouldReturnArrayWhenRotatedZeroTimes()
        {
            RoatateArray ra = new RoatateArray();
            int[] array = { 1, 2, 3, 4, 5 };
            int rotation = 0;
            int[] expectedResult = { 1, 2, 3, 4, 5 };
            int[] result = ra.Rotate(array, rotation);
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void ShouldRotateArray()
        {
            RoatateArray ra = new RoatateArray();
            int[] array = { 1, 2, 3, 4, 5 };
            int rotation = 2;
            int[] expectedResult = { 4, 5, 1, 2, 3 };
            int[] result = ra.Rotate(array, rotation);
            CollectionAssert.AreEqual(result, expectedResult);
        }
    }
}