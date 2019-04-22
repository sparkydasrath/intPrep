using System;

namespace TwoPointers
{
    public class RemoveDuplicatesFromSortedArray
    {
        /*
         * Problem 4: Given a sorted array that have repeating numbers, remove the duplicates in place
        • Ex: Input = [1 2 4 4 9 9 9 9], output = [1 2 4 9 0 0 0 0]

         */

        public int[] RemoveDuplicates(int[] nums)
        {
            /* need two pointers, let the last valid number in the array that does not need to be operated on

                     h t
            case 1: [1,2]
                if nums[head] < nums[tail]  move both head and tail

                         h t
            case 2: [1,2,4,4...]
                if (nums[head] == nums[tail] move tail until you find another number bigger than head
                    if found, replace nums[head + 1] with nums[tail] and advance head

            */

            if (nums.Length < 2) return nums;

            int tail = 0;
            int head = tail + 1;
            int[] results = new int[nums.Length];
            Array.Copy(nums, results, nums.Length);

            while (tail < results.Length && head < results.Length)
            {
                // case 1
                if (results[tail] < results[head])
                {
                    tail++;
                    head++;
                }

                // case 2
                else if (results[tail] == results[head])
                {
                    /* fix head, advance head
                    two sub cases:
                    1. advance head until we find another number greater than tail or
                    2. if we reach end of array, need to zero out remaining elements
                    */

                    head++;

                    // case 1 found element greater than head & tail is < results.Length

                    if (head == results.Length)
                    {
                        // did not find anything else greater than current head, so zero everything out
                        for (int i = tail + 1; i < nums.Length; i++) results[i] = 0;
                        break;
                    }

                    if (results[tail] < results[head])
                    {
                        // replace head + 1 and move head
                        results[tail + 1] = results[head];
                        tail++;
                    }
                }
            }

            return results;
        }
    }
}