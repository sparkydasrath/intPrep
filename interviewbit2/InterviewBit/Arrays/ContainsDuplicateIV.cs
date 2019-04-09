namespace Arrays
{
    public class ContainsDuplicateIV
    {
        /*
    https://www.geeksforgeeks.org/find-repeating-element-sorted-array-size-n/

        Find the only repeating element in a sorted array of size n

        Given a sorted array of n elements containing elements in range from 1 to n-1 i.e. one element occurs twice, the task is to find the repeating element in an array.

        Examples :

        Input :  arr[] = { 1, 2 , 3 , 4 , 4}
        Output :  4

        Input :  arr[] = { 1 , 1 , 2 , 3 , 4}
        Output :  1

         */

        // Returns index of second appearance of a repeating element. The function assumes that array
        // elements are in range from 1 to n-1.
        public int FindSecondDuplicate(int[] arr, int low, int high)
        {
            // low = 0 , high = n-1;
            if (low > high) return -1;

            int mid = (low + high) / 2;
            int m1 = mid + 1;

            // Check if the mid element is the repeating one
            int valAtMid = arr[mid];
            if (arr[mid] != mid + 1)
            {
                if (mid > 0 && arr[mid] == arr[mid - 1]) return mid;

                // If mid element is not at its position that means the repeated element is in left
                return FindSecondDuplicate(arr, low, mid - 1);
            }

            // If mid is at proper position then repeated one is in right.
            return FindSecondDuplicate(arr, mid + 1, high);
        }

        public int SearchDupes(int[] array, int element)
        {
            // https://programmingpraxis.com/2017/11/07/binary-search-with-duplicates/
            int lo = 0;
            int hi = array.Length - 1;
            int output = -1;
            while (hi > lo)
            {
                int mid = lo + (hi - lo) / 2;
                int val = array[mid];
                if (val < element)
                    lo = mid + 1; // right side
                else if (val > element)
                    hi = mid; // left side
                else
                {
                    output = mid;
                    hi = mid;
                }
            }
            return output;
        }

        // Function to find first or last occurrence of a given number in sorted array of integers.
        // If searchFirst is true, we return the first occurrence of the number else we return its
        // last occurrence
        private int FindFirstOrLastRepeatingElement(int[] nums, int valueToFind, bool searchFirst)
        {
            // https://www.techiedelight.com/count-occurrences-number-sorted-array-duplicates/ search
            // space is nums[low..high]
            int lo = 0;
            int hi = nums.Length - 1;

            // initialize the result by -1
            int result = -1;

            // iterate till search space contains at-least one element
            while (lo <= hi)
            {
                // find the mid value in the search space and compares it with target value
                int mid = (lo + hi) / 2;

                // if target is found, update the result
                if (valueToFind == nums[mid])
                {
                    result = mid;

                    // go on searching towards left (lower indices) to find first occurence
                    if (searchFirst)
                        hi = mid - 1;

                    // go on searching towards right (higher indices) to find last occurence
                    else
                        lo = mid + 1;
                }

                // if target is less than the mid element, discard right half
                else if (valueToFind < nums[mid])
                    hi = mid - 1;

                // if target is more than the mid element, discard left half
                else
                    lo = mid + 1;
            }

            // return the found index or -1 if the element is not found
            return result;
        }
    }
}