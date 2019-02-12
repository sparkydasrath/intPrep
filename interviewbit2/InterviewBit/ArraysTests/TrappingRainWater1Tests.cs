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
            TrappingRainWater1 trappingRainWater1 = new TrappingRainWater1();
            int result = trappingRainWater1.GetTotalAmountOfWater(input);
            Assert.That(result, Is.EqualTo(6));
        }
    }
}