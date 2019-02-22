using NUnit.Framework;
using System.Collections.Generic;

namespace Strings.Tests
{
    [TestFixture]
    public class FlipGameTests
    {
        [Test]
        public void ShouldFlipCorrectly()
        {
            FlipGame fg = new FlipGame();
            List<string> result = fg.GeneratePossibleNextMoves("++++");
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}