using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DecodeWaysTests
    {
        [Test]
        public void ShouldReturnNumberOfWaysToDecodeMessageDp()
        {
            DpDecodeWays dw = new DpDecodeWays();

            int result1 = dw.DecodeDp("226");
            Assert.That(result1, Is.EqualTo(3));

            int result = dw.DecodeDp("12321");
            Assert.That(result, Is.EqualTo(6));

            int result3 = dw.DecodeDp2("226");
            Assert.That(result3, Is.EqualTo(3));
        }
    }
}