using NUnit.Framework;

namespace Facebook.Tests
{
    [TestFixture]
    public class BasicCalculator2Tests
    {
        [Test]
        public void ShouldCalculate()
        {
            BasicCalculator2 bc = new BasicCalculator2();
            int result = bc.Calculate("3-2*2+4/2");
            Assert.That(result, Is.EqualTo(1));

        }

        [Test]
        public void ShouldCalculateWithSpace()
        {
            BasicCalculator2 bc = new BasicCalculator2();
            int result = bc.Calculate(" 3/2 ");
            Assert.That(result, Is.EqualTo(1));

        }
    }
}