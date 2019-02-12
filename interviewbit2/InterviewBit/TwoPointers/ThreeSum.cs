using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoPointers
{
    public class ThreeSum
    {
        /*
         * 15. 3Sum https://leetcode.com/problems/3sum/
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

        public int GetSum(int a, int b, int c) => a + b + c;

        public bool IsSumZero(int a, int b, int c) => a + b + c == 0;

        public List<IList<int>> ThreeSum1(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();

            // base conditions
            if (nums == null || nums.Length < 3) return results;

            // loop variables
            int first = 0;
            int second = first + 1;
            int third = second + 1;

            while (first < nums.Length)
            {
                // if the third pointer exceeds the list, advance the second pointer
                if (third >= nums.Length)
                {
                    // increment second and shift the third back down
                    second++;
                    third = second + 1;
                }

                // if the second pointer exceeds the list, advance the first pointer
                if (second >= nums.Length || third >= nums.Length)
                {
                    // move first one ahead
                    first++;
                    // increment other pointers respectively
                    second = first + 1;
                    third = second + 1;
                }

                // if all the pointers are on the last element, you are done traversing
                if (first < nums.Length && second < nums.Length && third < nums.Length)
                {
                    // check if the 3 pointers add up to 0
                    int firstVal = nums[first];
                    int secondVal = nums[second];
                    int thirdVal = nums[third];
                    if (IsSumZero(firstVal, secondVal, thirdVal))
                    {
                        // build result List
                        List<int> subresults = new List<int> { firstVal, secondVal, thirdVal };
                        // check if list is already in the result set
                        TryAddList(results, subresults);
                        third++;
                    }
                    else
                    {
                        // if sum of points != 0 advance the third pointer to extend the search window
                        third++;
                    }
                }
            }

            return results;
        }

        public List<IList<int>> ThreeSumWithSorting(int[] nums)
        {
            // https://leetcode.com/problems/3sum/discuss/7691/C-solution-using-sorting-beats-100-solutions
            List<IList<int>> results = new List<IList<int>>();

            // base conditions
            if (nums == null || nums.Length < 3) return results;
            Array.Sort(nums);

            for (int first = 0; first < nums.Length - 2; first++)
            {
                int second = first + 1;
                int third = nums.Length - 1;

                /* since we have sorted the array, this check ensures that we don't
                 check the same number again
                 ex: if after sorting we get -1 -1 0 1 2...
                     then no point checking the sum for -1 twice meaning we checked it
                     at index zero, but since index 1's value (-1) is the same as
                     as the previous index, ignore
                */
                if (first != 0 && nums[first] == nums[first - 1]) continue;

                while (second < third)
                {
                    //since first is constant in entire loop,
                    // if second is also same as previous iteration,
                    // then 3rd value will also be same.
                    // This will help optimization and removing duplicate results
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        second++;
                        continue;
                    }

                    int sum = GetSum(nums[first], nums[second], nums[third]);

                    if (sum == 0)
                    {
                        results.Add(new List<int> { nums[first], nums[second], nums[third] });
                        second++;
                        third--;
                    }
                    else if (sum > 0)
                    {   /*
                            Since have a closing window approach and the array is sorted, then
                            if the sum is > than expected, then the sum can only get smaller by
                            shrinking the window from the right
                         */
                        third--;
                    }
                    else
                    {
                        second++;
                    }
                }
            }

            return results;
        }

        public void TryAddList(List<IList<int>> results, List<int> subresults)
        {
            if (results.Count == 0)
            {
                results.Add(subresults);
                return;
            }

            bool alreadyPresent = false;

            foreach (List<int> list in results)
            {
                list.Sort();
                subresults.Sort();
                if (list.SequenceEqual(subresults))
                {
                    alreadyPresent = true;
                    break;
                }
            }

            if (!alreadyPresent)
                results.Add(subresults);
        }
    }
}