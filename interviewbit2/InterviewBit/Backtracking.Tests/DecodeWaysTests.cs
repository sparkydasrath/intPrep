using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class DecodeWaysTests
    {
        [Test]
        public void ShouldReturnNumberOfWaysToDecodeMessage()
        {
            DecodeWays dw = new DecodeWays();

            int result3 = dw.NumDecodings3("226");
            Assert.That(result3, Is.EqualTo(3));

            int result4 = dw.NumDecodings3("226");
            Assert.That(result4, Is.EqualTo(3));
        }
    }
}