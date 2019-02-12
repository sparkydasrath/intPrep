namespace General
{
    public class DpIntegerPartitionAndCoinChange
    {
        /*
         * https://www.geeksforgeeks.org/partition-problem-dp-18/
         * https://www.youtube.com/watch?v=ZaVM057DuzE (vivek)
         *  I found vivek's explanation much better than tushar as he always has the zero row/col as base cases
         *
         *  Points to remember:
         *  1. The concept of excluding means copy from the above cell (~14:34)
         *      for example, if you need to calculate the number of ways you can use coins {0 1 2 3} to total to 3
         *      a. EXCLUDE 3 - that means we can only use coins {0 1 2} to make 3, which is already in the matrix
         *          so basically go to position 2,3 and copy that value into the 3,3 position
         *      b. INCLUDE 3 - that means we have to find the remainder of the total amt - coin (ex: 3 - 3 = 0)
         *          and in the same row, go to the result of the subtraction
         *      c. Sum the results of a & b
         *
         *  2. As you go down the row (coin denomination), if the coin is greater than the current total being looked at
         *      just copy from above cell - this means that the current coin cannot contribute to the current total and it is
         *      the same case as being excluded
         */

        public int NumberOfWaysToSumGivenCoinsToTotal(int total, int[] coins)
        {
            /* setup dp matrix - break out the total to a basic count
                ex: if total = 5, we will have 0 1 2 3 4 5
               the row will be the coins

                do the typical setup of the first row and first column being the zero-th hypothetical cases

             * */

            int[,] dp = new int[coins.Length + 1, total + 1];

            /*
             *    CAREFUL: in the case of 0,0 -> it is asking how many ways can you make a total of zero using zero coins?
                    the answer is 1 so you HAVE to set 0,0 to 1 in this case or else the rest of the algo will fail
             */
            //dp[0, 0] = 1; // base case 1

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = 1;
                        break;
                    }

                    if (i > j)
                    {
                        // it is for the case where it is impossible for the coin to contribute to
                        // the sum so copy from the above cell
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        // excluded
                        int excluded = dp[i - 1, j];

                        // included first, do the current total - the coin denomination
                        int remainder = j - i;

                        // now on the same row, go to the remainder cell
                        int included = dp[i, remainder];

                        int sum = excluded + included;
                        dp[i, j] = sum;
                    }
                }
            }

            int result = dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
            return result;
        }
    }
}