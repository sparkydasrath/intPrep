using System;
using System.Linq;

namespace Arrays
{
    // ReSharper disable once InconsistentNaming
    public class MeetingRoomsII
    {
        /*
         * 253. Meeting Rooms II https://leetcode.com/problems/meeting-rooms-ii/
        Medium

        Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.

        Example 1:

        Input: [[0, 30],[5, 10],[15, 20]]
        Output: 2

        Example 2:

        Input: [[7,10],[2,4]]
        Output: 1

         */

        public bool IsOverlap(Interval current, Interval previous) => current.start < previous.end;

        public int MinMeetingRooms(Interval[] intervals)
        {
            // explanation https://leetcode.com/articles/meeting-rooms-ii/#

            /*
             *Algorithm

                Separate out the start times and the end times in their separate arrays.

                Sort the start times and the end times separately.
                Note that this will mess up the original correspondence of start times and end times.
                They will be treated individually now.

                We consider two pointers: s_ptr and e_ptr which refer to start pointer and end pointer.
                The start pointer simply iterates over all the meetings and the end pointer helps us track if a meeting has ended and if we can reuse a room.

                When considering a specific meeting pointed to by s_ptr, we check if this start timing
                is greater than the meeting pointed to by e_ptr. If this is the case then that would mean
                some meeting has ended by the time the meeting at s_ptr had to start.
                So we can reuse one of the rooms. Otherwise, we have to allocate a new room.

                If a meeting has indeed ended i.e. if start[s_ptr] >= end[e_ptr], then we increment e_ptr.

                Repeat this process until s_ptr processes all of the meetings.

             *
             */

            if (intervals == null || intervals.Length == 0) return 0;

            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i].start;
                end[i] = intervals[i].end;
            }

            Array.Sort(start);
            Array.Sort(end);

            int startPointer = 0;
            int endPointer = 0;
            int count = 0;

            while (startPointer < intervals.Length)
            {
                // a meeting is over and we can use that room
                if (start[startPointer] >= end[endPointer])
                {
                    count -= 1;
                    // advance the end
                    endPointer += 1;
                }
                // otherwise, there is a clash and we need to allocate a room
                count += 1;
                startPointer += 1;
            }

            return count;
        }

        public int MinMeetingRoomsOld(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;
            if (intervals.Length == 1) return 1;
            int count = 0;

            Interval[] sorted = intervals.OrderBy(s => s.start).ThenBy(e => e.end).ToArray();

            for (int current = 0; current < sorted.Length; current++)
            {
                if (current == 0) count++;
                else
                {
                    int cleaned = 0;
                    while (cleaned < current)
                    {
                        // if any of the previous meeting times ended before the current one started,
                        // reclaim the room
                        if (sorted[cleaned].end <= sorted[current].start)
                            count--;
                        cleaned++;
                    }

                    count++;

                    // if (IsOverlap(sorted[current], sorted[current - 1])) count++;
                }
            }

            return count;
        }
    }
}