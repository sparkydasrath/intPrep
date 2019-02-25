namespace Facebook
{
    public class ProductOfArrayExceptSelf
    {
        /*
         238. Product of Array Except Self https://leetcode.com/problems/product-of-array-except-self/
        Medium

        Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

        Example:

        Input:  [1,2,3,4]
        Output: [24,12,8,6]

        Note: Please solve it without division and in O(n).

        Follow up:
        Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)

         */

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] arr = new int[nums.Length];

            // forward
            int prod = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                prod = prod * nums[i];
                arr[i] = prod;
            }

            // backwards
            prod = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                arr[i] = prod * (i > 0 ? arr[i - 1] : 1);
                prod *= nums[i];
            }

            return arr;
        }

        public int[] ProductExceptSelf2(int[] input)
        {
            // explanation: https://www.youtube.com/watch?v=vB-81TB6GUc
            int[] leftArr = new int[input.Length];
            int n = input.Length;
            int left = 1;

            // left to right
            for (int i = 0; i < n; i++)
            {
                leftArr[i] = left;
                left = left * input[i];
            }

            int right = 1;
            int[] prodArr = leftArr;

            for (int i = n - 1; i >= 0; i--)
            {
                prodArr[i] = right * prodArr[i];
                right = right * input[i];
            }

            return prodArr;
        }
    }
}