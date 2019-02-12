namespace Arrays
{
    public class RoatateArray
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