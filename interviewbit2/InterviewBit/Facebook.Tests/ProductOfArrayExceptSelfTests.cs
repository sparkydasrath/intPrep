using NUnit.Framework;

namespace Facebook.Tests
{
    [TestFixture]
    public class ProductOfArrayExceptSelfTests
    {
        [Test]
        public void ShouldGetProductOfArrayExceptSelf()
        {
            ProductOfArrayExceptSelf p = new ProductOfArrayExceptSelf();
            int[] exp = { 24, 12, 8, 6 };

            /*int[] result = p.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEqual(result, exp);*/

            int[] result2 = p.ProductExceptSelf2(new int[] { 1, 2, 3, 4 });
            CollectionAssert.AreEqual(result2, exp);
        }
    }
}