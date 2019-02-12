using System;
using System.Linq;

namespace BitManipulation
{
    public class PowerOf2ArraySum
    {
        /*
         * https://www.geeksforgeeks.org/smallest-power-of-2-which-is-greater-than-or-equal-to-sum-of-array-elements/
         *
         * Given an array of N numbers where values of the array represent memory sizes. The memory that is required by the system can only be represented in powers of 2. The task is to return the size of the memory required by the system.

            Examples:

            Input: a[] = {2, 1, 4, 5}
            Output: 16
            The sum of memory required is 12,
            hence the nearest power of 2 is 16.

            Input: a[] = {1, 2, 3, 2}
            Output: 8

         */

        public int NextPowerOf2(int[] arr)
        {
            int n = arr.Sum();

            return (int)Math.Ceiling(Math.Log(n, 2));
        }
    }
}