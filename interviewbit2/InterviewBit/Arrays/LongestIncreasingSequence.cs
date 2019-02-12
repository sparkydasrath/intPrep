using System;
using System.Linq;

namespace Arrays
{
    public class LongestIncreasingSequence
    {
        // https://miafish.wordpress.com/2016/07/08/leetcode-ojc-longest-increasing-subsequence/
        /*https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
            Note that while this is related to DpLongestCommonSubsequence,
            the subtle difference in how it is implemented is given in the problem statement
         *  In the BacktrackingLongestCommonSubsequence case, we are given 2 strings which imply
         *  the matrix solution
         *
         *  In this case, we are just given an array and while the solution is also in an array form
         *  the trick is to realize that you need to use the double pointer approach to solve this
         *
         *  For example, the outer variable, i, will iterate the original array, but j will always
         *  start at 0, and stay just behind i. Each time i is incremented, j starts back at zero
         *
         *  -----i  (i=5)
         *  -j      (j=1)
         *  --j     (j=2)
         *  ---j    (j=3)
         *  ----j   (j=4) now j is < i so the inner loop breaks and i = 6 and j starts back at 1
         *
         *  -----i  (i=6)
            -j      (j=1)
         */

        public int GetLongestIncreasingSequence(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int[] cache = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                cache[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j])
                        cache[i] = Math.Max(cache[i], cache[j] + 1);
                }
            }

            return cache.Max();
        }
    }
}