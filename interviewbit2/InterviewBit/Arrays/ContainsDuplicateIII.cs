using System;
using System.Text;

namespace Arrays
{
}

public class ContainsDuplicateIII
{
    /*
    https://www.geeksforgeeks.org/find-duplicates-in-on-time-and-constant-extra-space/
        Given an array of n elements which contains elements from 0 to n-1, with any of these numbers appearing any number of times.
        Find these repeating numbers in O(n) and using only constant memory space.

    For example, let n be 7 and array be {1, 2, 3, 1, 3, 6, 6}, the answer should be 1, 3 and 6.

        Algorithm:

            traverse the list for i= 0 to n-1 elements
            {
              check for sign of A[abs(A[i])] ;
              if positive then
                 make it negative by   A[abs(A[i])]=-A[abs(A[i])];
              else  // i.e., A[abs(A[i])] is negative
                 this   element (ith element of list) is a repetition
            }

     */

    public string ContainsDuplicateConstantSpace(int[] arr)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[Math.Abs(arr[i])] >= 0)
                arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
            else sb.Append(Math.Abs(arr[i]));
        }

        return sb.ToString();
    }
}