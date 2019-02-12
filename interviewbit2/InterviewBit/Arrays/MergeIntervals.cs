using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            if (y != null && (x != null && x.start > y.start)) return 1;
            if (x != null && (y != null && x.start < y.start)) return -1;
            return 0;
        }
    }

    public class MergeIntervals
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

        public bool IsFirstInsideSecond(Interval first, Interval second)
        {
            // check if first is inside the range of second

            bool isInside = first.start >= second.start && first.end <= second.end;
            return isInside;
        }

        public bool IsSecondInsideFirst(Interval first, Interval second)
        {
            // check if first is inside the range of second

            bool isInside = second.start >= first.start && second.end <= first.end;
            return isInside;
        }

        public List<Interval> Merge(List<Interval> intervals)
        {
            List<Interval> results = new List<Interval>();

            if (intervals == null || intervals.Count == 0) return results;

            if (intervals.Count == 1)
            {
                results.Add(intervals[0]);
                return results;
            }

            List<Interval> internalIntervals = new List<Interval>(intervals);
            internalIntervals.Sort(new IntervalComparer());

            Interval seed = TryGetMergedInterval(internalIntervals[0], internalIntervals[1]);

            if (seed != null) results.Add(seed);
            else
            {
                results.Add(internalIntervals[0]);
                results.Add(internalIntervals[1]);
            }

            for (int i = 2; i < internalIntervals.Count; i++)
            {
                // try merge the last result in the results list with the current item being looked
                // at in the internalIntervals list
                Interval merged = TryGetMergedInterval(results.Last(), internalIntervals[i]);

                if (merged != null)
                {
                    // successful merge, so need to replace the last item in result with the merged interval
                    results.RemoveAt(results.Count - 1);
                    results.Add(merged);
                }
                else
                {
                    // just add the current interval and continue
                    results.Add(internalIntervals[i]);
                }
            }

            return results;
        }

        public Interval TryGetMergedInterval(Interval first, Interval second)
        {
            Interval temp = first;

            if (second.start < first.start)
            {
                first = second;
                second = temp;
            }

            // there are three cases to check for

            if (second.start >= first.start &&
                second.start <= first.end &&
                first.end >= second.start &&
                first.end <= second.end)
            {
                return new Interval(first.start, second.end);
            }

            if (IsFirstInsideSecond(first, second)) { return second; }

            if (IsSecondInsideFirst(first, second)) { return first; }

            return null;
        }
    }
}