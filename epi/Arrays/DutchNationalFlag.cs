namespace Arrays
{
    public class DutchNationalFlag
    {
        /*
            Write a program that takes an array A and an index i into A, and rearranges the
            elements such that all elements less than A[i] (the "pivot") appear first, followed by
            elements equal to the pivot, followed by elements greater than the pivot
         */

        public int[] SortDnf1(int[] nums, int index)
        {
            int smaller = 0;
            int indexVal = nums[index];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < indexVal)
                {
                    Swap(nums, smaller, i);
                    smaller++;
                }
            }

            int larger = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] >= larger)
                {
                    Swap(nums, larger, i);
                    larger--;
                }
            }

            return nums;
        }

        private void Swap(int[] nums, int idx1, int idx2)
        {
            int val1 = nums[idx1];
            nums[idx1] = nums[idx2];
            nums[idx2] = val1;
        }
    }
}