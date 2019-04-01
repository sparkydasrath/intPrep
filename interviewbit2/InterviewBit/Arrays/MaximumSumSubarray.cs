using System;

namespace Arrays
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

        public int MaxProduct(int[] nums) => 0;
    }

    public class MaximumSumSubarray
    {
        /*
         53. Maximum Subarray
        Easy

        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        Example:

        Input: [-2,1,-3,4,-1,2,1,-5,4],
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.

        Follow up:

        If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

         */

        public int MaxSubArrayBigOn2(int[] nums)
        {
            int max = 0;
            for (int tail = 0; tail < nums.Length; tail++)
            {
                int sum = 0;
                sum += nums[tail];
                for (int head = tail + 1; head < nums.Length; head++)
                {
                    sum += nums[head];
                    if (sum >= Math.Max(max, sum))
                        max = sum;
                }
            }

            return max;
        }

        public int MaxSubArrayBigOnv1(int[] nums)
        {
            // https://leetcode.com/problems/maximum-subarray/discuss/20211/Accepted-O(n)-solution-in-java
            if (nums == null || nums.Length == 0) return 0;

            // First, we need to keep track of current minimum subarray sum we've seen so far
            int currMin = 0;
            // Second, we need to keep track of current sum of subarray so far
            int currSum = 0;
            // everytime we find currSum - currMin > maxSum, we will update maxSum
            int maxSum = int.MinValue;

            // iterate through input nums array
            foreach (int num in nums)
            {
                // get sum of current subarray [0 ... num]
                currSum += num;
                // check to see if we need to update maxSum
                if (currSum - currMin > maxSum) maxSum = currSum - currMin;
                // update current min
                currMin = Math.Min(currMin, currSum);
            }
            return maxSum;
        }

        public int MaxSubArrayBigOnv2(int[] nums)
        {
            // https://leetcode.com/problems/maximum-subarray/discuss/20211/Accepted-O(n)-solution-in-java
            int maxSumSoFar = 0;
            int maxSum = int.MinValue;
            foreach (int num in nums)
            {
                int sum = maxSumSoFar + num;
                maxSumSoFar = Math.Max(sum, num);
                maxSum = Math.Max(maxSum, maxSumSoFar);
            }

            return maxSum;
        }
    }
}