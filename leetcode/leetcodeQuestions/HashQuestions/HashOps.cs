using System;
using System.Collections.Generic;

namespace HashQuestions
{
    public class HashOps
    {
        public int FirstUniqChar(string s)
        {
            /*
             Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

        Examples:

        s = "leetcode"
        return 0.

        s = "loveleetcode",
        return 2.
        */
            if (s == null || s.Length <= 1) return -1;

            Dictionary<int, Tuple<int, int>> d = new Dictionary<int, Tuple<int, int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (d.ContainsKey(s[i]))
                {
                    Tuple<int, int> item = d[s[i]];
                    int updated = item.Item2 + 1;
                    d[s[i]] = new Tuple<int, int>(item.Item1, updated);
                }
                else d.Add(s[i], new Tuple<int, int>(i, 1));
            }

            foreach (Tuple<int, int> v in d.Values)
            {
                if (v.Item2 == 1) return v.Item1;
            }

            return -1;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            /*
             * Given two arrays, write a function to compute their intersection.

               Example 1:

               Input: nums1 = [1,2,2,1], nums2 = [2,2]
               Output: [2]

               Example 2:

               Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
               Output: [9,4]

               Note:

               Each element in the result must be unique.
               The result can be in any order.

             */

            Dictionary<int, int> d = new Dictionary<int, int>();
            List<int> res = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!d.ContainsKey(nums1[i]))
                {
                    d.Add(nums1[i], 1);
                    continue;
                }
                if (d.ContainsKey(nums1[i]))
                {
                    int x = d[nums1[i]] + 1;
                    d[nums1[i]] = x;
                }
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (!d.ContainsKey(nums2[i])) continue;
                int item = nums2[i];
                res.Add(nums2[i]);
                d[item] -= 1;
                if (d[item] <= 0) d.Remove(item);
            }

            if (res.Count == 0) return new int[0];

            return res.ToArray();
        }

        public int SingleNumber(int[] nums)
        {
            /*
             * Given a non-empty array of integers, every element appears twice except for one. Find that single one.

               Note:

               Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

               Example 1:

               Input: [2,2,1]
               Output: 1

               Example 2:

               Input: [4,1,2,1,2]
               Output: 4

             */

            Array.Sort(nums);
            int found = int.MinValue;
            for (int i = 0; i < nums.Length; i += 2)
            {
                int j = i + 1;

                if (j < nums.Length && nums[i] == nums[j]) continue;
                if (j > nums.Length - 1 && i == nums.Length - 1) // edge case [1,1,3]
                {
                    found = nums[i];
                    break;
                }

                if (nums[i] != nums[j])
                {
                    int a = i + 1;
                    int b = j + 1;
                    if (nums[a] == nums[b]) // [1,1,2,3,3] or [1,2,2]
                    {
                        found = nums[i];
                        break;
                    }
                }
            }

            return found;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            /*
             * Given an array of integers, return indices of the two numbers such that they add up to a specific target.

               You may assume that each input would have exactly one solution, and you may not use the same element twice.

               Example:

               Given nums = [2, 7, 11, 15], target = 9,

               Because nums[0] + nums[1] = 2 + 7 = 9,
               return [0, 1].

             */
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int toCheck = target - nums[i];
                if (d.ContainsKey(toCheck))
                    return new[] { d[toCheck], i };
                if (!d.ContainsKey(nums[i]))
                {
                    d.Add(nums[i], i);
                }
            }

            return null;
        }
    }
}