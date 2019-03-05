using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationSequenceTests
    {
        [Test]
        public void ShouldGetPermutationSequence()
        {
            PermutationSequence ps = new PermutationSequence();
            string result = ps.GetPermutation(3, 3);
            Assert.That(result, Is.EqualTo("213"));
        }
    }
}