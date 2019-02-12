using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class MajorityElementTests
    {
        [Test]
        public void ShouldReturnMajorityElement()
        {
            int[] elements = { 1, 1, 1, 1, 2, 3, 1 };
            MajorityElement me = new MajorityElement();
            int result = me.GetMajorityElement(elements);
            Assert.That(result, Is.EqualTo(1));
        }
    }
}