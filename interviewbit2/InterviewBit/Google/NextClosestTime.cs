using System.Collections.Generic;

namespace Google
{
    public class NextClosestTime
    {
        /*
         * 681. Next Closest Time https://leetcode.com/problems/next-closest-time/
        Medium

        Given a time represented in the format "HH:MM", form the next closest time by reusing the current digits. There is no limit on how many times a digit can be reused.

        You may assume the given input string is always valid. For example, "01:34", "12:09" are all valid. "1:34", "12:9" are all invalid.

        Example 1:

        Input: "19:34"
        Output: "19:39"
        Explanation: The next closest time choosing from digits 1, 9, 3, 4, is 19:39, which occurs 5 minutes later.  It is not 19:33, because this occurs 23 hours and 59 minutes later.

        Example 2:

        Input: "23:59"
        Output: "22:22"
        Explanation: The next closest time choosing from digits 2, 3, 5, 9, is 22:22. It may be assumed that the returned time is next day's time since it is smaller than the input time numerically.

        TOTALLY DID NOT GET THIS ONE AT ALL
        Intuition and Algorithm

        Simulate the clock going forward by one minute. Each time it moves forward, if all the digits are allowed, then return the current time.

        The natural way to represent the time is as an integer t in the range 0 <= t < 24 * 60.
        Then the hours are t / 60, the minutes are t % 60, and each digit of the hours and minutes can be found by hours / 10, hours % 10 etc.

         */

        public string NextClosestTimeImplementation(string time)
        {
            // take all the digits and put them in a set
            HashSet<int> set = new HashSet<int>();
            foreach (char c in time)
            {
                if (c != ':')
                    set.Add(c - '0');
            }

            // convert the current time to minutes
            int hrPart = int.Parse(time.Substring(0, 2)) * 60;
            int minPart = int.Parse(time.Substring(3, 2));

            int currentTime = hrPart + minPart;
            int maxTimeInMinutes = 24 * 60;

            int hr1 = 0;
            int hr2 = 0;
            int min1 = 0;
            int min2 = 0;
            int count = 0;
            while (count < 4)
            {
                currentTime = (currentTime + 1) % maxTimeInMinutes;
                // convert the current time back to digits
                hr1 = currentTime / 60 / 10;
                hr2 = currentTime / 60 % 10;
                min1 = currentTime % 60 / 10;
                min2 = currentTime % 60 % 10;

                int[] convertedDigits = { hr1, hr2, min1, min2 };

                foreach (int digit in convertedDigits)
                {
                    // if the set contains all the digits, we have a winner
                    if (set.Contains(digit))
                    {
                        count++;
                        continue;
                    }

                    // if (count == convertedDigits.Length) return hr1.ToString() + hr2 + ":" + min1
                    // + min2;
                    count = 0;
                }
            }
            return hr1.ToString() + hr2 + ":" + min1 + min2;
        }
    }
}