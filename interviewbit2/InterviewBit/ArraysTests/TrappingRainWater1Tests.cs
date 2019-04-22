using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class TrappingRainWater1Tests
    {
        [Test]
        public void ShouldReturnTotalArea()
        {
            int[] input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            TrappingRainWater trappingRainWater = new TrappingRainWater();
            int result = trappingRainWater.GetTotalAmountOfWater(input);
            Assert.That(result, Is.EqualTo(6));
        }
    }
}