using System.Linq;

namespace Arrays
{
    public class MeetingRoomsI
    {
        /*
         * 252. Meeting Rooms https://leetcode.com/problems/meeting-rooms/
            Easy

            Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), determine if a person could attend all meetings.

            Example 1:

            Input: [[0,30],[5,10],[15,20]]
            Output: false

            Example 2:

            Input: [[7,10],[2,4]]
            Output: true

         */

        public bool CanAttendMeetings(Interval[] intervals)
        {
            /*
             *  Similar to the MergeIntervals problem
             * The idea is that if you sort all the intervals
             *  Then starting from the second interval to the end of the list of intervals, if
             *  the start of the current interval is less than the end of the previous one, it means
             *  the intervals are overlapping and the person cannot attend all meetings
             *
             */
            if (intervals.Length == 0) return true;

            Interval[] sorted = intervals.OrderBy(s => s.start).ThenBy(e => e.end).ToArray();

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i].start < sorted[i - 1].end) return false;
            }

            return true;
        }
    }
}