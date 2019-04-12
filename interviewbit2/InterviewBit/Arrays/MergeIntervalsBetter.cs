using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class MergeIntervalsBetter
    {
        /*
        * 56. Merge Intervals https://leetcode.com/problems/merge-intervals/
        Medium

        Given a collection of intervals, merge all overlapping intervals.

        Example 1:

        Input: [[1,3],[2,6],[8,10],[15,18]]
        Output: [[1,6],[8,10],[15,18]]
        Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].

        Example 2:

        Input: [[1,4],[4,5]]
        Output: [[1,5]]
        Explanation: Intervals [1,4] and [4,5] are considered overlapping.
         */

        public List<Interval> Merge(List<Interval> intervals)
        {
            List<Interval> results = new List<Interval>();

            if (intervals == null || intervals.Count == 0) return results;

            /*
             *  based on the description on leetcode
             * 1. sort the initial list based on a custom comparer
             * 2. add the first item of the sorted list immediately into the result list
             * 3. iterate from the 2nd item to end of sorted list and check cases
             *  3a if the the start of the current item in the sorted list is >  the end of the last item in the result list - no overlap
             *  3b otherwise they overlap (not need to check if one is completely in the other like I did)
             *      and we merge them by updating the end of the previous interval (from the result list)
             *      if it is less than the end of the current interval.
             *
             */

            List<Interval> sortedIntervals = intervals.OrderBy(c => c.start).ThenBy(c => c.end).ToList();

            foreach (Interval interval in sortedIntervals)
            {
                if (results.Count == 0 || interval.start > results.Last().end)
                {
                    // no overlap so just add to result list
                    results.Add(interval);
                }
                else
                {
                    // do simple merge without needed extra function just take the max between the
                    // last item in the result set and the end of the current sorted item
                    results.Last().end = Math.Max(results.Last().end, interval.end);
                }
            }

            return results;
        }
    }
}