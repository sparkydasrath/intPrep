using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class FlipGame2Tests
    {
        [Test]
        public void ShouldTestMoves()
        {
            FlipGame2 fg = new FlipGame2();
            bool result = fg.CanWin("++++");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldTestMoves2()
        {
            FlipGame2 fg = new FlipGame2();
            bool result = fg.CanWinUsingFlipGame1("++++");
            Assert.IsTrue(result);
        }
    }
}