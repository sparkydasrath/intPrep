using System.Collections.Generic;

namespace Arrays
{
    public class TwoSum
    {
        /*
         *Given an array of integers, return indices of the two numbers such that they add up to a specific target.

           You may assume that each input would have exactly one solution, and you may not use the same element twice.

           Example:

           Given nums = [2, 7, 11, 15], target = 9,

           Because nums[0] + nums[1] = 2 + 7 = 9,
           return [0, 1].

         */

        public int[] TwoSumCheck(int[] nums, int target)
        {
            // this one with two pointers dont seem to work
            if (nums.Length == 0) return new int[] { };

            int[] results = new int[2];

            int i = 0;
            int j = nums.Length - 1;

            while (i < j)
            {
                int sum = nums[i] + nums[j];

                if (sum == target)
                {
                    results[0] = i;
                    results[1] = j;
                }
                else if (sum < target) i++;
                else if (sum > target) j--;
            }

            return results;
        }

        public int[] TwoSumCheckWithDictionary(int[] nums, int target)
        {
            // store the number as the key and the index as the value
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int next = target - nums[i];
                if (dictionary.ContainsKey(next))
                {
                    // if the target minus current value is in the dictionary then it's complement
                    // was already in there
                    result[0] = dictionary[next];
                    result[1] = i;
                }
                else
                {
                    dictionary[nums[i]] = i;
                }
            }

            //Array.Sort(result);
            return result;
        }
    }
}