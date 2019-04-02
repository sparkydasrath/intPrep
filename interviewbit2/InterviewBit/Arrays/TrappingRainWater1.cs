using System;

namespace Arrays
{
    public class TrappingRainWater1
    {
        /*
         42. Trapping Rain Water https://leetcode.com/problems/trapping-rain-water/
        Hard

        Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

        The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

        Example:

        Input: [0,1,0,2,1,0,1,3,2,1,2,1]
        Output: 6

         */

        public int GetTotalAmountOfWater(int[] heights)
        {
            int results = 0;
            int left = 0;
            int right = heights.Length - 1;
            int maxLeft = 0;
            int maxRight = 0;

            while (left <= right)
            {
                int heightsLeft = heights[left];
                int heightsRight = heights[right];
                maxLeft = Math.Max(maxLeft, heightsLeft);
                maxRight = Math.Max(maxRight, heightsRight);

                if (maxLeft <= maxRight)
                {
                    heightsLeft = heights[left];
                    results += maxLeft - heightsLeft;
                    left++;
                }
                else
                {
                    heightsRight = heights[right];
                    results += maxRight - heightsRight;
                    right--;
                }
            }

            return results;
        }
    }
}