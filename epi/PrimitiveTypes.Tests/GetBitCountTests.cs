using NUnit.Framework;

namespace PrimitiveTypes.Tests
{
    [TestFixture]
    public class GetBitCountTests
    {
        [TestCase(5, ExpectedResult = 2)] /*5 = 101*/
        [TestCase(21, ExpectedResult = 3)] /*20 = 10101*/
        public int ShouldCountBits(int n)
        {
            CountBits cb = new CountBits();
            int results = cb.GetBitCount(n);
            return results;
        }
    }
}