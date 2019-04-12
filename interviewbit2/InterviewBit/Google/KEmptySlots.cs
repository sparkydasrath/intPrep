using System;

namespace Google
{
    public class KEmptySlots
    {
        /*
         * 683. K Empty Slots https://leetcode.com/problems/k-empty-slots/
        Hard

        There is a garden with N slots. In each slot, there is a flower. The N flowers will bloom one by one in N days.
        In each day, there will be exactly one flower blooming and it will be in the status of blooming since then.

        Given an array flowers consists of number from 1 to N. Each number in the array represents the place where the flower will open in that day.

        For example, flowers[i] = x means that the unique flower that blooms at day i will be at position x, where i and x will be in the range from 1 to N.

        Also given an integer k, you need to output in which day there exists two flowers in the status of blooming, and also the number of flowers between them is k and these flowers are not blooming.

        If there isn't such day, output -1.

        Example 1:

        Input:
        flowers: [1,3,2]
        k: 1
        Output: 2
        Explanation: In the second day, the first and the third flower have become blooming.

        Example 2:

        Input:
        flowers: [1,2,3]
        k: 1
        Output: -1

         */

        public int KEmptySlotsLc(int[] flowers, int k)
        {
            int[] days = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++)
            {
                days[flowers[i] - 1] = i + 1;
            }

            return -1;
        }

        public int KEmptySlotsMinev1(int[] flowers, int k)
        {
            int[] flowers2 = new int[flowers.Length + 1];

            for (int i = 1; i < flowers2.Length; i++)
            {
                flowers2[i] = flowers[i - 1];
            }

            int day = -1;

            // two pointers, head & tail where tail = head + 1 to start off with iterate from head =
            // 0 to N-1 (to avoid tail overflow)
            for (int head = 1; head < flowers2.Length - 1; head++)
            {
                // easy case [1 2 3] there is no gap > 1
                int tail = head + 1;

                // check diff between head & tail array value

                // if flowers[tail] - flowers[head] == 1 head++; tail = head + 1;
                if (flowers2[tail] - flowers2[head] != 1)
                {
                    tail++;
                    // if flowers[tail] - flowers[head] > 1 // have potential no bloom section the
                    // current position of head is the left boundary
                    while (tail < flowers2.Length)
                    {
                        // fix head and advance tail, getting the diff at each tail increment
                        int diff = flowers2[tail] - flowers2[head];

                        if (diff == 1) // found a consecutive day with a blooming flower
                        {
                            // if it is true then check the range between head tail to see if it ==
                            // k, find the midpoint to get day
                            if (tail - head - 1 == k && k % 2 != 0)
                            {
                                day = (head + tail) / 2;
                            }
                        }

                        tail++;
                    }
                }
            }
            return day;
        }

        public int KEmptySlotsMinev2(int[] flowers, int k)
        {
            /*
             *  After reading a million explanations and solutions I finally got the gist of what's happening
             *
             *  I did not think to transform the flowers to a day array - I still don't understand how that works
             *
             *  While I figured out it was a window problem, my solution is cumbersome, and a good solution
             *  is dependent on getting the days array
             *  In the end you will get a window where the flowers at the ends are the boundary and blooming
             *   and the k slots in the middle are unbloomed. But the key here is that you create the window
             *   with the left and right days and that window size is FIXED, i.e. left, right = k + 1
             *
             *
             *      l--- i ---r
             *
             *  Now for this to be valid, we figure out the max of l & r => max(l, r) and every i between
             *      l and r will have to have a blooming day > that BOTH l and r and the size of the range must
             *      equal k
             *
             *  https://leetcode.com/problems/k-empty-slots/discuss/107948/Iterate-over-time-vs.-iterate-over-position
             *
             */

            int[] days = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++)
            {
                // this transforms the flower/position array to a day/position array
                days[flowers[i] - 1] = i + 1;
            }

            int left = 0;
            int right = k + 1;
            int noOfDays = int.MaxValue;
            int n = days.Length;

            for (int i = 1; i < n && right < n; i++)
            {
                int daysCurrent = days[i];
                int daysLeft = days[left];
                int daysRight = days[right];

                if (daysCurrent < daysLeft || daysCurrent <= daysRight)
                {
                    if (daysCurrent == daysRight)
                    {
                        int maxBetweenLeftAndRightToConsider = Math.Max(daysLeft, daysRight);
                        noOfDays = Math.Min(noOfDays, maxBetweenLeftAndRightToConsider);
                    }
                    // we have hit the case where we have flower that bloomed earlier than our two
                    // end flowers so this range is invalid adjust the window
                    left = i;
                    right = i + k + 1;
                }
            }

            return noOfDays > n ? -1 : noOfDays;
        }
    }
}