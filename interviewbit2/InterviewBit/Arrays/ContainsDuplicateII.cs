using System.Collections.Generic;

namespace Arrays
{
    public class ContainsDuplicateII
    {
        /*
         219. Contains Duplicate II
        Easy

        Given an array of integers and an integer k, find out whether there are two distinct indices i and j
        in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.

        Example 1:

        Input: nums = [1,2,3,1], k = 3
        Output: true

        Example 2:

        Input: nums = [1,0,1,1], k = 1
        Output: true

        Example 3:

        Input: nums = [1,2,3,1,2,3], k = 2
        Output: false

         */

        // ! The way this problem is worded in crap - it has more downvotes than up. Based on the LC
        // ! solution, you just want to maintain a set of size k???

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            // https://leetcode.com/problems/contains-duplicate-ii/solution/
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i])) return true;
                set.Add(nums[i]);
                if (set.Count > k)
                    set.Remove(nums[i - k]);
            }

            return false;
        }

        public bool ContainsNearbyDuplicateMine(int[] nums, int k)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dictionary.ContainsKey(nums[i])) dictionary.Add(nums[i], i);

                // if it does contain the key already, we found a dupe, i.e the case where nums[i] =
                // nums[j] just need to check if the diff in indices is k

                int indexInDictionary = dictionary[nums[i]];
                if (i - indexInDictionary == k) return true;

                /* need to handle the case when there are multiple of the same number in the list
                 ex: {1, 0, 1, 1}

                so the idea is to remove the first occurence of this dupe and add the current one
                ex: will remove the 1 at index 0 and add the 1 at index 2
                */

                dictionary.Remove(nums[i]);
                dictionary.Add(nums[i], i);
            }

            return false;
        }
    }
}