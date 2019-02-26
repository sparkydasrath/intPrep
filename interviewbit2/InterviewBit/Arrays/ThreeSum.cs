using System;
using System.Collections.Generic;

namespace Arrays
{
    public class ThreeSum
    {
        /*
            15. 3Sum https://leetcode.com/problems/3sum/
            Medium

            Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

            Note:

            The solution set must not contain duplicate triplets.

            Example:

            Given array nums = [-1, 0, 1, 2, -1, -4],

            A solution set is:
            [
              [-1, 0, 1],
              [-1, -1, 2]
            ]

         */

        // seems the main trick here is first SORTING the given array
        // note: TwoSum uses Dictionary to solve problem, does not work here

        public List<List<int>> ThreeSumCheck(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    List<int> partialResult = new List<int> { nums[left], nums[i], nums[right] };
                    partialResult.Sort();
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(partialResult);
                        left++;
                        right--;
                    }
                    else if (sum < 0) left++;
                    else if (sum > 0) right--;
                }
            }

            return result;
        }
    }
}