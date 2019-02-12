using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class MinArrowsToBurstBalloonsTests
    {
        [Test]
        public void ShouldReturnMinArrows()
        {
            MinArrowsToBurstBalloons min = new MinArrowsToBurstBalloons();
            int[,] input = {
                {10,16 },
                {2,8 },
                {1,6 },
                {7,12 },
            };
            int count = min.FindMinArrowShots(input);
            Assert.That(count, Is.EqualTo(2));
        }
    }
}