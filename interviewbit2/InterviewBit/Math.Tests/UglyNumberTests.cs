using NUnit.Framework;

namespace Math.Tests
{
    [TestFixture]
    public class UglyNumberTests
    {
        [TestCase(300, ExpectedResult = true)]
        public bool IsUgly(int n)
        {
            UglyNumber u = new UglyNumber();
            int nithUgly = u.GetNthUglyNo(9);
            Assert.That(nithUgly, Is.EqualTo(10));
            return u.IsUgly(n);
        }
    }
}