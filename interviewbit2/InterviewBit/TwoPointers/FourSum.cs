using System;
using System.Collections.Generic;

namespace TwoPointers
{
    public class FourSum
    {
        public List<IList<int>> FourSumSortAndWindow(int[] nums, int target)
        {
            /*
             * ABANDONED
             * this approach was trying to use two shrinking windows and it works partially
             *
             */
            List<IList<int>> results = new List<IList<int>>();

            if (nums.Length == 0 || nums.Length < 4) return results;

            Array.Sort(nums);

            // only need to iterate to n-2 spots since those can be potentially be referred to by the
            // right window pointers
            for (int one = 0; one < nums.Length - 3; one++) // outerleft
            {
                // create pointers
                int two = one + 1; // inner left
                int four = nums.Length - 1; // outer right
                int three = four - 1; // inner right

                while (one < four && two < three)
                {
                    int outerSum = nums[one] + nums[four];
                    int innerSum = nums[two] + nums[three];
                    int fullSum = nums[one] + nums[two] + nums[three] + nums[four];

                    // if (two > one + 1 && nums[two] == nums[two - 1])

                    // check if the current pointers sum is a valid target
                    if (fullSum == target)
                    {
                        // add items to results
                        results.Add(new List<int> { nums[one], nums[two], nums[three], nums[four] });
                        two++;
                        three--;
                    }
                    else if (outerSum > target)
                    {
                        // move the right window to the left as it implies that a sum can only be
                        // found to the left since the current sum exceeds the target
                        four--;
                        three = four - 1;
                    }
                    else if (outerSum < target)
                    {
                        // same as outer case but from left
                        one++;
                        two = one + 1;
                    }
                    else if (innerSum > target)
                    {
                        // adjust the right inner window
                        three--;
                    }
                    else
                    {
                        two++;
                    }
                }
            }

            return results;
        }

        public List<IList<int>> FourSumSortAndWindowAndFirstTwoFixed(int[] nums, int target)
        {
            /*
             * Looks like my shrinking window approach worked partially
             * It seems the strategy is to still fix two indices and create a window with the remaining space
             * Extending ThreeSum where you fix the first item and created a window with second and third,
             *  here you fix first & second (hence the need for TWO for loops) and make a window with the other two
             * https://leetcode.com/problems/4sum/discuss/171054/Java-Solution-with-explain.-Really-EASY-to-understand
             *
             */

            List<IList<int>> results = new List<IList<int>>();

            if (nums.Length == 0 || nums.Length < 4) return results;

            Array.Sort(nums);

            // only need to iterate to n-2 spots since those can be potentially be referred to by the
            // right window pointers
            for (int one = 0; one < nums.Length - 3; one++)
            {
                if (one > 0 && nums[one] == nums[one - 1]) continue; // remove dupe
                for (int two = one + 1; two < nums.Length - 2; two++)
                {
                    if (two > one + 1 && nums[two] == nums[two - 1]) continue; // remove dupe
                    // create pointers
                    int left = two + 1; // inner right
                    int right = nums.Length - 1; // outer right

                    while (left < right)
                    {
                        int sum = nums[one] + nums[two] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            results.Add(new List<int> { nums[one], nums[two], nums[left], nums[right] });

                            // skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;
                            left++;
                            right--;
                        }
                        else if (sum > target) right--;
                        else left++;
                    }
                }
            }

            return results;
        }
    }
}