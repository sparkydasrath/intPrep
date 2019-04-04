using NUnit.Framework;

namespace Math.Tests
{
    [TestFixture]
    public class ReverseIntegerTests
    {
        [TestCase(123, ExpectedResult = 321)]
        public int ShouldReverseInt(int x)
        {
            ReverseInteger r = new ReverseInteger();
            return r.Reverse(x);
        }
    }
}