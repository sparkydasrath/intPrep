using System;
using System.Collections.Generic;

namespace arrays01
{
    /*
     In a given integer array nums, there is always exactly one largest element.

Find whether the largest element in the array is at least twice as much as every other number in the array.

If it is, return the index of the largest element, otherwise return -1.

Example 1:

Input: nums = [3, 6, 1, 0]
Output: 1
Explanation: 6 is the largest integer, and for every other number in the array x,
6 is more than twice as big as x.  The index of value 6 is 1, so we return 1.

Example 2:

Input: nums = [1, 2, 3, 4]
Output: -1
Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
 */

    public class DominantIndex
    {
        public int GetDominantIndex(int[] nums)
        {
            int largest = 0;
            int largestIndex = 0;
            int iteration = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= largest)
                {
                    largest = nums[i];
                    largestIndex = i;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == largestIndex) continue;  // skip the pivot element
                int twice = nums[i] * 2;
                if (largest >= twice) iteration++;
            }

            if (iteration == nums.Length - 1) return largestIndex;
            return -1;
        }

        public int[] PlusOne(int[] digits)
        {
            /*
             *
             * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.

        The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.

        You may assume the integer does not contain any leading zero, except the number 0 itself.

        Example 1:

        Input: [1,2,3]
        Output: [1,2,4]
        Explanation: The array represents the integer 123.

        Example 2:

        Input: [4,3,2,1]
        Output: [4,3,2,2]
        Explanation: The array represents the integer 4321.

             */

            if (digits[digits.Length - 1] != 9)
            {
                int lpOne = digits[digits.Length - 1] + 1;
                int[] temp = (int[])digits.Clone();
                temp[digits.Length - 1] = lpOne;
                return temp;
            }
            else
            {
                List<int> nines = new List<int>();
                //1. need to find consecutive 9s
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (digits[i] == 9)
                    {
                        nines.Add(i);
                        // we went through the list and hit the end, all the items so far are 9s
                        if (i == 0)
                        {
                            int[] biggerArray = new int[digits.Length + 1];
                            Array.Clear(biggerArray, 0, biggerArray.Length);
                            biggerArray[0] = 1;
                            return biggerArray;
                        }
                    }
                    else
                    {
                        // we have some consecutive 9s like 8 9 9 9 and have hit the first value we
                        // can safely add one
                        int[] temp = digits;
                        int valPlusOne = digits[i] + 1;
                        temp[i] = valPlusOne;
                        for (int j = 0; j < nines.Count; j++)
                        {
                            int index = nines[j];
                            temp[index] = 0;
                        }
                        return temp;
                    }
                }
                return null;
            }
        }
    }
}