using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class FlippingAnImageTests
    {
        [Test]
        public void ShouldFlipArrayOfArrays()
        {
            FlippingAnImage fi = new FlippingAnImage();
            int[][] input =
            {
                new[]{1,1,0 },
                new[]{ 1,0,1},
                new[]{ 0, 0, 0 }
            };
            int[][] result = fi.FlipAndInvertImage(input);

            CollectionAssert.AreEqual(result[0], new int[] { 1, 0, 0 });
        }
    }
}