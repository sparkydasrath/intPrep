using System;
using System.Linq;

namespace General
{
    public class DpMinimumNumberOfJumps
    {
        /*  https://www.youtube.com/watch?v=jH_5ypQggWg (vivek)
         *  https://www.youtube.com/watch?v=cETfFsSTGJI (tushar)
         *  https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/MinJumpToReachEnd.java
         *
         * PROBLEM (this was kinda hard to understand wtf they were asking)
         *  https://practice.geeksforgeeks.org/problems/minimum-number-of-jumps/0
         *
         * Given an array of integers where each element represents the max number of steps that can be made forward from that element. Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). If an element is 0, then cannot move through that element.

           Input:
           The first line contains an integer T, depicting total number of test cases.
           Then following T lines contains a number n denoting the size of the array.
           Next line contains the sequence of integers a1, a2, ..., an.

           Output:
           Each separate line showing the minimum number of jumps. If answer is not possible print -1.

           Constraints:
           1 ≤ T ≤ 40
           1 ≤ N ≤ 100
           0<=a[N]<=100

           Example:

           Input:

           1
           11
           1 3 5 8 9 2 6 7 6 8 9

           Output:

           3

           Space complexity O(n) to maintain result and min jumps
           Time complexity O(n^2)
         *
         */

        public int MinimumNumberOfJumps(int[] n)
        {
            int[] dpMinJumpsArr = Enumerable.Repeat(int.MaxValue, n.Length).ToArray();
            dpMinJumpsArr[0] = 0; // the first length is always zero

            int[] pathArray = new int[n.Length];

            for (int i = 1; i < n.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // this check is to figure out if i is in range of each j value
                    // https://www.youtube.com/watch?v=jH_5ypQggWg @ 630
                    if (i <= j + n[j])
                    {
                        dpMinJumpsArr[i] = Math.Min(dpMinJumpsArr[i], dpMinJumpsArr[j] + 1);
                        pathArray[i] = j;
                    }
                }
            }

            int result = dpMinJumpsArr[dpMinJumpsArr.Length - 1];

            return result;
        }
    }
}