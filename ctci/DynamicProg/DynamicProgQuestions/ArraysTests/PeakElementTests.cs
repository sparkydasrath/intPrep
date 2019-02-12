using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class PeakElementTests
    {
        [Test]
        public void ShouldReturnPeakElement()
        {
            int[] elements = { 5, 8, 15, 28, 36, 48, 68, 52, 32, 17 };
            PeakElement pe = new PeakElement();
            int sol1 = pe.GetPeakElement(elements);
            Assert.That(sol1, Is.EqualTo(68));
        }
    }
}