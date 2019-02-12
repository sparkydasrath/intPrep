namespace arrays01
{
    /*
         Given an array of integers nums, write a method that returns the "pivot" index of this array.

        We define the pivot index as the index where the sum of the numbers to the left of the index is equal to the sum of the numbers to the right of the index.

        If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.

        Example 1:
        Input:
        nums = [1, 7, 3, 6, 5, 6]
        Output: 3
        Explanation:
        The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.
        Also, 3 is the first index where this occurs.

        Example 2:
        Input:
        nums = [1, 2, 3]
        Output: -1
        Explanation:
        There is no index that satisfies the conditions in the problem statement.
        Note:

        The length of nums will be in the range [0, 10000].
        Each element nums[i] will be an integer in the range [-1000, 1000].
         */

    public class PivotIndex
    {
        public int GetPivotIndex(int[] nums)
        {
            int result = -1;
            int pivot = 1;

            while (pivot < nums.Length)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int i = 0; i < pivot; i++)
                {
                    leftSum += nums[i];
                }

                for (int i = pivot + 1; i < nums.Length; i++)
                {
                    rightSum += nums[i];
                }

                if (leftSum == rightSum)
                {
                    result = pivot;
                    break;
                }

                pivot++;
            }

            return result;
        }

        public int GetPivotIndexBetter(int[] nums)
        {
            int sum = 0;
            int leftSum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum - leftSum - nums[i] == leftSum) return i;
                leftSum += nums[i];
            }

            return -1;
        }
    }
}