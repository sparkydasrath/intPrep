using Utils;

namespace General
{
    //todo another fucking pain in the ass dp problem
    public class DpSubsetSumProblemBase
    {
        /*  * Given an array of non negative numbers and a total, is there subset of numbers in this array which adds up
           * to given total. Another variation is given an array is it possible to split it up into 2 equal
           * sum partitions. Partition need not be equal sized. Just equal sum.
         *  https://www.youtube.com/watch?v=K20Tx8cdwYY (vivek)
         * https://www.youtube.com/watch?v=s6FhG--P7z0&t=16s (tushar)
         *
         */

        public bool IsSubsetSumEqualToGivenSum(int[] n, int sum)
        {
            bool[,] dp = new bool[n.Length + 1, sum + 1];

            // first set the zero-th row to false (except @ position 0,0) and set first column to true
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (i == 0) dp[i, j] = false;
                    if (j == 0) dp[i, j] = true;
                }
            }

            MatrixUtils.PrintMatrixGeneric(dp);

            for (int i = 1; i < dp.GetLength(0); i++)
            {
                // want to skip the zero-th column
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                }
            }

            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}