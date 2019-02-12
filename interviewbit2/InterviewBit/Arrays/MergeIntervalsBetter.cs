using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class MergeIntervalsBetter
    {
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