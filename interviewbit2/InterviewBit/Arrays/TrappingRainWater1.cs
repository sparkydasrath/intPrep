using System;

namespace Arrays
{
    public class TrappingRainWater1
    {
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