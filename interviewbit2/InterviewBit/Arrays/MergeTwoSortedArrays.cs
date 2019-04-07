using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class MergeTwoSortedArrays
    {
        /*
         88. Merge Sorted Array
        Easy

        Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

        Note:

            The number of elements initialized in nums1 and nums2 are m and n respectively.
            You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.

        Example:

        Input:
        nums1 = [1,2,3,0,0,0], m = 3
        nums2 = [2,5,6],       n = 3

        Output: [1,2,2,3,5,6]

         */

        public int[] Merge(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null) return new int[] { };
            if (nums1 == null || nums1.Length == 0) return nums2;
            if (nums2 == null || nums2.Length == 0) return nums1;

            int first = 0;
            int second = 0;

            int nums1Length = nums1.Length;
            int nums2Length = nums2.Length;

            List<int> results = new List<int>();

            while (first < nums1Length || second < nums2Length)
            {
                if (first < nums1Length && nums1[first] <= nums2[second])
                {
                    results.Add(nums1[first]);
                    first++;
                }
                else if (second < nums2Length)
                {
                    results.Add(nums2[second]);
                    second++;
                }
            }

            // check for left over elements
            if (first < nums1Length)
                results.AddRange(nums1.Skip(nums1Length - first));
            if (second < nums2Length)
                results.AddRange(nums2.Skip(nums2Length - second));

            int[] arrayResult = results.ToArray();

            return arrayResult;
        }
    }
}