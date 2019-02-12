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

            int head = 0;
            int tail = head + 1;
            int[] results = new int[nums.Length];
            Array.Copy(nums, results, nums.Length);

            while (head < results.Length && tail < results.Length)
            {
                // case 1
                if (results[head] < results[tail])
                {
                    head++;
                    tail++;
                }

                // case 2
                else if (results[head] == results[tail])
                {
                    /* fix head, advance tail
                    two sub cases:
                    1. advance tail until we find another number greater than head or
                    2. if we reach end of array, need to zero out remaining elements
                    */

                    tail++;

                    // case 1 found element greater than head & tail is < results.Length

                    if (tail == results.Length)
                    {
                        // did not find anything else greater than current head, so zero everything out
                        for (int i = head + 1; i < nums.Length; i++) results[i] = 0;
                        break;
                    }

                    if (results[head] < results[tail])
                    {
                        // replace head + 1 and move head
                        results[head + 1] = results[tail];
                        head++;
                    }
                }
            }

            return results;
        }
    }
}