using System;

namespace General
{
    public class DpCoinChanging
    {
        //todo need to figure out my shitty index out of bounds

        /* https://www.youtube.com/watch?v=Y0ZqKpToTic&index=6&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&t=0s
         *  Tushar's version
         * I can't seem to get this one sorted out just yet due to coming up with corner cases
         */

        public int MinCoinsNeededForSum1(int sumToCompute, int[] coins)
        {
            /* https://www.youtube.com/watch?v=Y0ZqKpToTic&index=6&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&t=0s
       *  Tushar's version
             * Going to try this again
             *
             * */

            int[,] dp = new int[coins.Length + 1, sumToCompute + 1];

            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    int currentCoin = coins[i - 1];
                    // special case for the 1 denomination coin will need 2 1-coin to sum to 2, 5
                    // 1-coin to sum to 5 etc basically the same as j as you loop
                    if (currentCoin == 1)
                    {
                        dp[1, j] = j;
                        continue;
                    }

                    if (j < currentCoin) dp[i, j] = dp[i - 1, j];
                    else
                    {
                        // exclude current coin (i)
                        int aboveCellValue = dp[i - 1, j];

                        // include current coin (i) - but need to remove/discount it from the current
                        // total (j)
                        int included = j - currentCoin;
                        int currentTotalMinusCoin = dp[i, included];
                        int minValueBetweenExcludedAndIncluded = Math.Min(aboveCellValue, currentTotalMinusCoin + 1);
                        dp[i, j] = minValueBetweenExcludedAndIncluded;
                    }
                }
            }

            int result = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            return result;
        }

        public int MinCoinsNeededForSum1Failed(int sumToCompute, int[] coins)
        {
            int c = coins.Length;
            int[,] dp = new int[c, sumToCompute + 1];

            for (int coin = 0; coin < coins.Length; coin++)
            {
                for (int sum = 1; sum <= sumToCompute; sum++)
                {
                    int currentCoin = coins[coin]; // 1,5,6,8
                    int goBackByCurrentCoinValue = sum - currentCoin;   // total - coin value

                    // top row but your coin is greater than your total
                    // ex: you start off with coins of denomination 5 cents instead of 1 cent this
                    // means that as long as the total is less than 5, there is no way to use that
                    // 5cent coin
                    if (coin == 0 && sum < coin)
                    {
                        dp[coin, sum] = 0;
                    }

                    // still on the top row, but now the coin can be used as part of the total total
                    else if (coin == 0 && sum >= coin)
                    {
                        dp[coin, sum] = 1 + dp[coin, goBackByCurrentCoinValue];
                    }

                    // moved past the top row and can use it's values to get the next row any total
                    // less than the current coin's denomination can only be contributed to the coins
                    // before this row
                    else if (coin > 0 && sum < coin)
                    {
                        // copy from previous row
                        dp[coin, sum] = dp[coin - 1, sum];
                    }

                    // basically go back the denomination of the coin to 'include it' in the total
                    else
                    {
                        int previousBasedOnCoinValue = 1 + dp[coin, sum - coins[coin]];
                        int aboveCellValue = dp[coin - 1, sum];
                        // this means we have already populated the first row
                        dp[coin, sum] = Math.Min(previousBasedOnCoinValue, aboveCellValue);
                    }
                }
            }

            return dp[c, sumToCompute]; // return last cell
        }
    }
}