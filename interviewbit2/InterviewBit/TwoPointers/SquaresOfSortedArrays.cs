using System;

namespace TwoPointers
{
    public class SquaresOfSortedArrays
    {
        /*
         * 977. Squares of a Sorted Array
            Easy

            Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number, also in sorted non-decreasing order.

            Example 1:
            Input: [-4,-1,0,3,10]
            Output: [0,1,9,16,100]

            Example 2:
            Input: [-7,-3,2,3,11]
            Output: [4,9,9,49,121]

            Note:

                1 <= A.length <= 10000
                -10000 <= A[i] <= 10000
                A is sorted in non-decreasing order.

                  strategy:
        start at index zero, have a variable MIN to store the min value being looked at
            wallk through the array and find the math.abs min element since the squares is always positive
        once we id the element we can store that at index 0

        the idea is to use two pointers where the head will be the min we have found so far and the tail will search for the next min
            when the next min if found and squared, advance the head
         */

        public int[] SortedSquaresSimple(int[] input)
        {
            int[] ans = new int[input.Length];
            for (int i = 0; i < input.Length; ++i)
                ans[i] = input[i] * input[i];

            Array.Sort(ans);
            return ans;
        }

        public int[] SortedSquaresTwoPointer(int[] input)
        {
            if (input.Length == 0) return input;

            int[] nums = new int[input.Length];
            Array.Copy(input, nums, nums.Length);

            int min = int.MaxValue;
            int minIndex = 0;
            int head = -1;
            int tail = 0;

            while (head < nums.Length)
            {
                // head will store the last min found

                // compare the tail with the current min
                if (tail < nums.Length && Math.Abs(nums[tail]) < min)
                {
                    // if it is a valid min, update min, advance tail

                    min = Math.Abs(nums[tail]);
                    minIndex = tail;
                    tail++; // advance the tail
                }

                // if a new min is found, store its index and value

                // if you reach end of array and no more new min is found , swap the found min and
                // reset the min to math.max
                else if (tail >= nums.Length)
                {
                    head++;

                    //swap
                    Swap(nums, head, minIndex);
                    nums[head] = (int)Math.Pow(nums[head], 2);
                    tail = head + 1;

                    // reset min
                    min = int.MaxValue;

                    if (tail >= nums.Length)
                        break; // we have swapped and the tail is overflowing
                }
                else
                    tail++;
            }

            return nums;
        }

        public void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}