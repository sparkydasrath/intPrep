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
        public int GetMaxProfitI(int[] prices)
        {
            BestTimeBuySellStockI s = new BestTimeBuySellStockI();
            int result = s.MaxProfit(prices);
            // int result = s.MaxProfitBigOn2(prices);
            return result;
        }

        [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, ExpectedResult = 7)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(new[] { 7, 6, 4, 3, 1 }, ExpectedResult = 0)]
        public int GetMaxProfitII(int[] prices)
        {
            BestTimeBuySellStockII s = new BestTimeBuySellStockII();
            int result = s.MaxProfit(prices);
            // int result = s.MaxProfitBigOn2(prices);
            return result;
        }
    }
}