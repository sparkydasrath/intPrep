using System;

namespace General
{
    public class DpLongestCommonSubsequence
    {
        /*
         * https://www.youtube.com/watch?v=43P0xZp3FU4
         * https://www.youtube.com/watch?v=NnD96abizww
         */

        public int LongestCommonSubsequence(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            int max = 0;
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        /*
                         * why the diagonal
                         *
                         *
                           In the first instance we were looking for common subsequence
                           between ab and b, so if we already had the count of subsequence
                           between a and null (which is diagonally top left of the current
                           cell) and then included b (which is common to both and is the
                           current cell), then the common subsequence would increase
                           by 1 (0 + 1). So when we find a common character we look at
                           what the count of the subsequence was before that character
                           was included, we do this by looking at the value of the cell
                           diagonally top left of the current cell﻿
                         */
                        dp[i, j] = dp[i - 1, j - 1] + 1; // get from the diagonal
                    }
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]); // get max from the above and the previous cell

                    if (dp[i, j] > max)
                        max = dp[i, j];
                }
            }

            return max;
        }
    }
}