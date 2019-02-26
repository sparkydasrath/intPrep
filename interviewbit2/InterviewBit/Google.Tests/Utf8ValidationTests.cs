using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class Utf8ValidationTests
    {
        // [TestCase(new[] { 197, 130, 1 }, ExpectedResult = true)]
        [TestCase(new[] { 235, 140, 4 }, ExpectedResult = false)]
        public bool Validate(int[] data)
        {
            Utf8Validation u = new Utf8Validation();
            bool result = u.ValidUtf8(data);
            return result;
        }
    }
}