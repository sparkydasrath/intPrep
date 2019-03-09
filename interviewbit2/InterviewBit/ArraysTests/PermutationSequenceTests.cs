using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class PermutationSequenceTests
    {
        [Test]
        public void ShouldGetPermutationSequence()
        {
            PermutationSequence ps = new PermutationSequence();
            string result = ps.GetPermutation(4, 14);
            Assert.That(result, Is.EqualTo("3142"));
        }

        [Test]
        public void ShouldGetPermutationSequenceTimeout()
        {
            PermutationSequence ps = new PermutationSequence();
            string result = ps.GetPermutation_TimelimitExceeded(3, 3);
            Assert.That(result, Is.EqualTo("213"));
        }
    }
}