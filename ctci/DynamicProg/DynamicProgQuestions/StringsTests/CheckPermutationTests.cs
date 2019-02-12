using NUnit.Framework;
using Strings;

namespace StringsTests
{
    [TestFixture]
    public class CheckPermutationTests
    {
        [Test]
        public void ShouldReturnTrueIfPermutation()
        {
            CheckPermutation string01 = new CheckPermutation();
            bool res = string01.IsPermutation("one", "oen");
            Assert.That(res, Is.True);
        }
    }
}