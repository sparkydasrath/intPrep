using System.Linq;

namespace Arrays
{
    public class MinArrowsToBurstBalloons
    {
        /*
         * 452. Minimum Number of Arrows to Burst Balloons https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/
        Medium

        There are a number of spherical balloons spread in two-dimensional space. For each balloon, provided input is the start and end coordinates of the horizontal diameter. Since it's horizontal, y-coordinates don't matter and hence the x-coordinates of start and end of the diameter suffice. Start is always smaller than end. There will be at most 104 balloons.

        An arrow can be shot up exactly vertically from different points along the x-axis. A balloon with xstart and xend bursts by an arrow shot at x if xstart ≤ x ≤ xend. There is no limit to the number of arrows that can be shot. An arrow once shot keeps travelling up infinitely. The problem is to find the minimum number of arrows that must be shot to burst all balloons.

        Example:

        Input:
        [[10,16], [2,8], [1,6], [7,12]]

        Output:
        2

        Explanation:
        One way is to shoot one arrow for example at x = 6 (bursting the balloons [2,8] and [1,6]) and another arrow at x = 11 (bursting the other two balloons).

            https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/discuss/93734/C-sort-by-start-count-when-start-is-non-overlapping

             Here I sort by start and keep track of the current balloon. The idea is that if the next balloon overlaps you don't need to use another arrow.
             The only catch is that if the overlapping balloon ends earlier you need to adjust your end marker to the lesser
             of the ends.
             */

        public int FindMinArrowShots(int[,] points)
        {
            if (points.GetLength(0) == 0) return 0;

            Interval[] intervals = PointsToIntervals(points);
            Interval[] sorted = intervals.OrderBy(s => s.start).ThenBy(e => e.end).ToArray();

            int count = 0;
            Interval prevInterval = null;
            for (int i = 0; i < sorted.Length; i++)
            {
                Interval currInterval = sorted[i];

                if (prevInterval == null || currInterval.start > prevInterval.end)
                {
                    // handles the non-onverlapping case
                    count++;
                    prevInterval = currInterval;
                }
                else if (currInterval.end < prevInterval.end)
                {
                    prevInterval.end = currInterval.end;
                }
            }

            return count;
        }

        private Interval[] PointsToIntervals(int[,] points)
        {
            Interval[] results = new Interval[points.GetLength(0)];

            for (int i = 0; i < points.GetLength(0); i++)
            {
                results[i] = new Interval(points[i, 0], points[i, 1]);
            }

            return results;
        }
    }
}