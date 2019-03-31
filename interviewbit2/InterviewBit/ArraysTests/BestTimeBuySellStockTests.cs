using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class BestTimeBuySellStockTests
    {
        [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, ExpectedResult = 5)]
        [TestCase(new[] { 7, 6, 4, 3, 1 }, ExpectedResult = 0)]
        [TestCase(new[] { 2, 4, 1 }, ExpectedResult = 2)]
        public int GetMaxProfit(int[] prices)
        {
            BestTimeBuySellStockI s = new BestTimeBuySellStockI();
            int result = s.MaxProfit(prices);
            // int result = s.MaxProfitBigOn2(prices);
            return result;
        }
    }
}