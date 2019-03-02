using NUnit.Framework;

namespace PrimitiveTypes.Tests
{
    [TestFixture]
    public class ParityOfWordTests
    {
        [TestCase(8, ExpectedResult = 1)]
        public int GetParity(long n)
        {
            ParityOfWord p = new ParityOfWord();
            short result = p.GetParity(n);
            return result;
        }
    }
}