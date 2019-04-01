using System;

namespace Arrays
{
    public class BestTimeBuySellStockI
    {
        /*
         121. Best Time to Buy and Sell Stock https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        Easy

        Say you have an array for which the ith element is the price of a given stock on day i.

        If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

        Note that you cannot sell a stock before you buy one.

        Example 1:

        Input: [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                     Not 7-1 = 6, as selling price needs to be larger than buying price.

        Example 2:

        Input: [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transaction is done, i.e. max profit = 0.

         */

        public int MaxProfit(int[] prices)
        {
            // https://leetcode.com/articles/best-time-to-buy-and-sell-stock/#
            int minprice = int.MaxValue;
            int maxprofit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                    minprice = prices[i];
                else if (prices[i] - minprice > maxprofit)
                    maxprofit = prices[i] - minprice;
            }
            return maxprofit;
        }

        public int MaxProfitBigOn2(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            int max = int.MinValue;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    int diff = prices[j] - prices[i];
                    max = Math.Max(max, diff);
                }
            }

            return max < 0 ? 0 : max;
        }
    }
}