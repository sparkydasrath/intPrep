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
        public int FindRepeatingElement(int[] arr, int low, int high)
        {
            // low = 0 , high = n-1;
            if (low > high) return -1;

            int mid = (low + high) / 2;

            // Check if the mid element is the repeating one
            int valAtMid = arr[mid];
            if (arr[mid] != mid + 1)
            {
                if (mid > 0 && arr[mid] == arr[mid - 1]) return mid;

                // If mid element is not at its position that means the repeated element is in left
                return FindRepeatingElement(arr, low, mid - 1);
            }

            // If mid is at proper position then repeated one is in right.
            return FindRepeatingElement(arr, mid + 1, high);
        }

        // Function to find first or last occurrence of a given number in sorted array of integers.
        // If searchFirst is true, we return the first occurrence of the number else we return its
        // last occurrence
        private int BinarySearch(int[] nums, int arrayLength, int x, bool searchFirst)
        {
            // https://www.techiedelight.com/count-occurrences-number-sorted-array-duplicates/ search
            // space is nums[low..high]
            int low = 0, high = arrayLength - 1;

            // initialize the result by -1
            int result = -1;

            // iterate till search space contains at-least one element
            while (low <= high)
            {
                // find the mid value in the search space and compares it with target value
                int mid = (low + high) / 2;

                // if target is found, update the result
                if (x == nums[mid])
                {
                    result = mid;

                    // go on searching towards left (lower indices)
                    if (searchFirst)
                        high = mid - 1;

                    // go on searching towards right (higher indices)
                    else
                        low = mid + 1;
                }

                // if target is less than the mid element, discard right half
                else if (x < nums[mid])
                    high = mid - 1;

                // if target is more than the mid element, discard left half
                else
                    low = mid + 1;
            }

            // return the found index or -1 if the element is not found
            return result;
        }

        private int SearchDupes(int[] array, int n, int element)
        {
            // https://programmingpraxis.com/2017/11/07/binary-search-with-duplicates/
            int lo = 0;
            int hi = n;
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
    }
}