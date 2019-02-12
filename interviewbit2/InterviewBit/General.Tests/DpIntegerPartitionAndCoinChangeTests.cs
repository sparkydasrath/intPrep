using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DpIntegerPartitionAndCoinChangeTests
    {
        [TestCase(5, new[] { 1, 2, 3, 4, 5 }, ExpectedResult = 7)]
        public int GetNumberOfWaysToSumCoins(int total, int[] coins)
        {
            DpIntegerPartitionAndCoinChange coinChange = new DpIntegerPartitionAndCoinChange();
            int result = coinChange.NumberOfWaysToSumGivenCoinsToTotal(total, coins);
            return result;
        }
    }
}