using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DpCoinChangingTests
    {
        [TestCase(11, new[] { 1, 5, 6, 8 }, ExpectedResult = 2)]
        public int ShouldGetTheMinNumberOfCoinsNeededToComputeGivenSumFromSetOfCoins(int sum, int[] coins)
        {
            DpCoinChanging dpc = new DpCoinChanging();
            int result = dpc.MinCoinsNeededForSum1(sum, coins);
            return result;
        }
    }
}