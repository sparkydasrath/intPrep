using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class ContainerWithMostWaterTests
    {
        [Test]
        public void ShouldReturnMaxArea()
        {
            int[] heights = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            ContainerWithMostWater c = new ContainerWithMostWater();
            int maxArea = c.MaxArea(heights);
            Assert.That(maxArea, Is.EqualTo(49));
        }
    }
}