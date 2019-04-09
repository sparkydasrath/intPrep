using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class MedianOfTwoSortedArrays
    {
        /*
         4. Median of Two Sorted Arrays
            Hard

            There are two sorted arrays nums1 and nums2 of size m and n respectively.

            Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

            You may assume nums1 and nums2 cannot be both empty.

            Example 1:

            nums1 = [1, 3]
            nums2 = [2]

            The median is 2.0

            Example 2:

            nums1 = [1, 2]
            nums2 = [3, 4]

            The median is (2 + 3)/2 = 2.5

         */

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();

            int firstIndex = 0;
            int secondIndex = 0;

            while (firstIndex < nums1.Length || secondIndex < nums2.Length)
            {
                if (firstIndex < nums1.Length && nums1[firstIndex] <= nums2[secondIndex])
                {
                    result.Add(nums1[firstIndex]);
                    firstIndex++;
                }
                else if (secondIndex < nums2.Length)
                {
                    result.Add(nums2[secondIndex]);
                    secondIndex++;
                }
            }

            // add leftovers
            if (firstIndex < nums2.Length)
            {
                // have leftevers in nums2
                result.AddRange(nums1.Skip(nums1.Length - firstIndex));
            }
            else if (secondIndex < nums2.Length)
            {
                result.AddRange(nums2.Skip(nums2.Length - secondIndex));
            }

            int mid = (0 + result.Count - 1) / 2;
            double median;
            if (result.Count % 2 == 0)       // even case
                median = (result[mid] + result[mid + 1]) / 2d;
            else median = result[mid];

            return median;
        }
    }
}