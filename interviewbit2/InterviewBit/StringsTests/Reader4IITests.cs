using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class Reader4IITests
    {
        [Test]
        public void ShouldReturnCorrectCount()
        {
            Reader4II r2 = new Reader4II();
            char[] buf = new char[10000];
            int result1 = r2.Read(buf, 1);
            int result2 = r2.Read(buf, 2);
            int result3 = r2.Read(buf, 10);
            Assert.That(result1, Is.EqualTo(1));
            Assert.That(result2, Is.EqualTo(2));
            // there are only 5 items in the file and 3 were already removed
            Assert.That(result3, Is.EqualTo(2));
        }
    }
}