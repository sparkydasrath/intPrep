namespace Arrays
{
    public class NextPermutation
    {
        /*
         31. Next Permutation https://leetcode.com/problems/next-permutation/
        Medium

        Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

        If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

        The replacement must be in-place and use only constant extra memory.

        Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.

        1,2,3 → 1,3,2
        3,2,1 → 1,2,3
        1,1,5 → 1,5,1

         */

        public void NextPerm(int[] nums)
        {
            if (nums.Length == 1) return;
            /*

                nums = 1 2 3 6 5 8
                               ^
                               i points here so that i + 1 will point at nums.length -1
             */

            int i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i])
                i--;

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                    j--;

                Swap(nums, i, j);
            }

            ReverseArray(nums, i + 1);
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void ReverseArray(int[] nums, int start)
        {
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }
    }
}