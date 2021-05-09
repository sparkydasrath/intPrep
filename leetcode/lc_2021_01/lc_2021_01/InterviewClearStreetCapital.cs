using System;

namespace lc_2021_01
{
    public class InterviewClearStreetCapital
    {
        // tests from codesignal.com

        public static int BuyAndSellStock(int[] prices)
        {
            // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/discuss/204181/C
            if (prices.Length == 0) return 0;
            int minProfit = int.MaxValue;
            int maxProfit = int.MinValue;
            foreach (int p in prices)
            {
                minProfit = Math.Min(minProfit, p);
                maxProfit = Math.Max(maxProfit, p - minProfit);
            }
            
            return maxProfit;

        }
    }
}