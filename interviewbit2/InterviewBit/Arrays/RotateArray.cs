namespace Arrays
{
    public class FindElementInRotatedSortedArray
    {
        /*
         * https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/
         *
         *
           Search an element in a sorted and rotated array

           An element in a sorted array can be found in O(log n) time via binary search.
           But suppose we rotate an ascending order sorted array at some pivot unknown to you beforehand. So for instance, 1 2 3 4 5 might become 3 4 5 1 2. Devise a way to find an element in the rotated array in O(log n) time.

           Input  : arr[] = {5, 6, 7, 8, 9, 10, 1, 2, 3};
           key = 3
           Output : Found at index 8

           Input  : arr[] = {5, 6, 7, 8, 9, 10, 1, 2, 3};
           key = 30
           Output : Not found

           Input : arr[] = {30, 40, 50, 10, 20}
           key = 10
           Output : Found at index 3

            EXPLANATION: https://www.youtube.com/watch?v=5BI0Rdm9Yhk (vivek)

            NOTE: The idea is to use Binary Search to find the pivot element of the rotation first

        */

        public int FindPivotIndex(int s, int e, int[] n)
        {
            int mid = (s + e) / 2;

            if (n[mid] > n[s])
            {
                // pivot is in the second half
                return FindPivotIndex(mid + 1, e, n);
            }

            if (n[mid] < n[s])
            {
                // pivot is in first half
                return FindPivotIndex(s, mid - 1, n);
            }
            return mid + 1; // found pivot
        }
    }

    public class RotateArray
    {
        public int[] Rotate(int[] nums, int k)
        {
            if (k == 0 || k == nums.Length) return nums;
            int len = nums.Length - 1;
            while (k != 0)
            {
                int lastElement = nums[len];
                for (int i = nums.Length - 1; i > 0; i--)
                {
                    int j = i - 1;
                    nums[i] = nums[j];
                }
                nums[0] = lastElement;
                k--;
            }
            return nums;
        }

        /*https://www.youtube.com/watch?v=EpP6YuqzHe8
         This version breaks the arrays in two parts and reversing the arrays to get the final rotated array

        ex: N = 1 2 3 4 5 6 7 8 9
        rotate by 3 so you end up with 7 8 9 1 2 3 4 5 6

        take k-th last set of elements: 7 8 9
        reverse it: kr = 9 8 7

        take N-k: 1 2 3 4 5
        reverse it: Nr = 5 4 3 2 1

        append: Nr kr => 5 4 3 2 1 9 8 7

        reverse it all => 7 8 9 1 2 3 4 5

        Reverse Array without extra space:  https://www.youtube.com/watch?v=W-090WziKAs
         */
    }
}