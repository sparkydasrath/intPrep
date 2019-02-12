using System;

namespace StringQuestions
{
    public class TwoPointers
    {
        public int ArrayPairSum(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int half = nums.Length / 2;
            int sum = 0;
            for (int i = 0; i < half; i++)
            {
                int j = nums.Length - 1 - i;

                int minPair = Math.Min(nums[i], nums[j]);
                Console.WriteLine($"pair = {nums[i]},{nums[j]}");
                sum += minPair;
            }

            return sum;
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int j = 0;
            int cMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) j++;
                else
                {
                    if (j > cMax) cMax = j;
                    j = 0;
                }
            }
            if (j > cMax) cMax = j;
            return cMax;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int k = 0;
            // for (int i = 0; i < nums.Length; ++i)
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            /*
             * Given an array of integers, return indices of the two numbers such that they add up to a specific target.

               You may assume that each input would have exactly one solution, and you may not use the same element twice.

               Example:

               Given nums = [2, 7, 11, 15], target = 9,

               Because nums[0] + nums[1] = 2 + 7 = 9,
               return [0, 1].

             */
            int[] result = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                int first = numbers[i];
                int second = target - first;
                int secondIndex = Array.IndexOf(numbers, second, i + 1);
                if (secondIndex != -1)
                {
                    result[0] = i + 1;
                    result[1] = secondIndex + 1;
                    break;
                }
            }

            return result;
        }
    }
}