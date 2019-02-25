using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Google.Tests
{
    [TestFixture]
    public class MaximumProductSubarrayTests
    {
        [Test]
        public void ShouldGetMaximumProductSubarray()
        {
            MaximumProductSubarray m = new MaximumProductSubarray();
            int result = m.MaxProduct(new[] { 2, 3, -2, 4 });
            Assert.That(result, Is.EqualTo(6));
        }
    }
}