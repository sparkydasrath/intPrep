namespace Arrays
{
    public class FindElementInRotatedSortedArray
    {
        /*
         * https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/
         *
         *
           Search an element in a sorted and rotated array

           An element in a sorted array can be found in O(log nums) time via binary search.
           But suppose we rotate an ascending order sorted array at some pivot unknown to you beforehand. So for instance, 1 2 3 4 5 might become 3 4 5 1 2. Devise a way to find an element in the rotated array in O(log nums) time.

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

        public int FindPivotIndex(int start, int end, int[] nums)
        {
            int mid = (start + end) / 2;

            if (nums[mid] > nums[start])
            {
                // ! this is saying that if the mid > start then all elements ! from the start to the
                // ! mid is ALREADY SORTED so the pivot is in the second half
                return FindPivotIndex(mid + 1, end, nums);
            }

            if (nums[mid] < nums[start])
            {
                // pivot is in first half
                return FindPivotIndex(start, mid - 1, nums);
            }
            return mid + 1; // found pivot
        }

        public int FindPivotIndexNonRecursive(int[] nums)
        {
            // https://www.youtube.com/embed/ggLGjf_XiNQ?rel=0&showinfo=0
            if (nums == null || nums.Length == 0) return -1;

            // case when array is not rotated
            if (nums[0] <= nums[nums.Length - 1]) return nums[0];

            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] > nums[mid + 1]) return mid + 1; // found pivot

                if (nums[start] <= nums[mid])
                    start = mid + 1;  // result in second half
                else end = mid - 1; // result in first half
            }

            return 0;
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