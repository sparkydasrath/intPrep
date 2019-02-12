using System;

namespace Arrays
{
    public class ContainerWithMostWater
    {
        // https://leetcode.com/problems/container-with-most-water/
        /*
         *Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

           Note: You may not slant the container and n is at least 2.

        Example:

           Input: [1,8,6,2,5,4,8,3,7]
           Output: 49
         */

        /*
         * While I knew I needed a sliding window, I was attempting to start both sliders
         * from the beginning ex: i=0, j=1 and that was complicating matters
         * The trick was to start at start and end and collapse the pointers
         *
         */

        public int MaxArea(int[] heights)
        {
            if (heights.Length <= 1) return 0;
            int leftPointer = 0;
            int rightPointer = heights.Length - 1;
            int maxArea = 0;

            while (leftPointer < rightPointer)
            {
                int width = rightPointer - leftPointer;
                int height = Math.Min(heights[leftPointer], heights[rightPointer]);
                int area = GetArea(width, height);

                if (area > maxArea) maxArea = area;

                if (heights[leftPointer] < heights[rightPointer]) leftPointer++;
                else rightPointer--;
            }

            return maxArea;
        }

        private int GetArea(int width, int height) => width * height;
    }
}