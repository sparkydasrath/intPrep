using System;

namespace Google
{
    public class MaxConsecutiveOnes
    {
        /*
         * 485. Max Consecutive Ones https://leetcode.com/problems/max-consecutive-ones/
        Easy

        Given a binary array, find the maximum number of consecutive 1s in this array.

        Example 1:

        Input: [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s.
            The maximum number of consecutive 1s is 3.

        Note:

            The input array will only contain 0 and 1.
            The length of input array is a positive integer and will not exceed 10,000

         */

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    max = Math.Max(count, max);
                    count = 0;
                }
                else
                    count++;
            }

            return Math.Max(count, max);
        }
    }
}