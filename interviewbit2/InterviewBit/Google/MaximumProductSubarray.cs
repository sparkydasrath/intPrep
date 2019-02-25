using System;

namespace Google
{
    public class MaximumProductSubarray
    {
        /*
         152. Maximum Product Subarray https://leetcode.com/problems/maximum-product-subarray/
        Medium

        Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

        Example 1:

        Input: [2,3,-2,4]
        Output: 6
        Explanation: [2,3] has the largest product 6.

        Example 2:

        Input: [-2,0,-1]
        Output: 0
        Explanation: The result cannot be 2, because [-2,-1] is not a subarray.

         */

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int globalMax = nums[0];

            int preMin = nums[0];
            int preMax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int curMin = 0;
                int curMax = 0;

                if (nums[i] == 0)
                {
                    curMin = 0;
                    curMax = 0;
                }
                else if (nums[i] < 0)
                {
                    // element is negative
                    curMin = Math.Min(nums[i], nums[i] * preMax);
                    curMax = Math.Max(nums[i], nums[i] * preMin);
                }
                else if (nums[i] > 0)
                {
                    curMin = Math.Min(nums[i], nums[i] * preMin);
                    curMax = Math.Max(nums[i], nums[i] * preMax);
                }

                preMin = curMin;
                preMax = curMax;

                globalMax = Math.Max(preMax, globalMax);
            }

            return globalMax;
        }
    }
}