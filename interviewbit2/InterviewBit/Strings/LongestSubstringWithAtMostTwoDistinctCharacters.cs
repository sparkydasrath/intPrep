using System;
using System.Collections.Generic;
using System.Linq;

namespace Strings
{
    public class LongestSubstringWithAtMostTwoDistinctCharacters
    {
        /*
         159. Longest Substring with At Most Two Distinct Characters https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
        Hard

        Given a string s , find the length of the longest substring t  that contains at most 2 distinct characters.

        Example 1:

        Input: "eceba"
        Output: 3
        Explanation: t is "ece" which its length is 3.

        Example 2:

        Input: "ccaabbb"
        Output: 5
        Explanation: t is "aabbb" which its length is 5.
        soln:  https://leetcode.com/articles/longest-substring-with-at-most-two-distinct-charac/#
         */

        public int LengthOfLongestSubstringTwoDistinct1(string s)
        {
            // mine + https://miafish.wordpress.com/2015/04/04/leetcode-ojc-longest-substring-with-at-most-two-distinct-characters/

            if (s.Length < 3) return s.Length;

            // store the char and it's right most position
            Dictionary<char, int> charPositionMap = new Dictionary<char, int>();
            int max = 2;

            int tail = 0;
            for (int head = 0; head < s.Length; head++)
            {
                char currChar = s[head];

                // need to make it less than 3 to get at least 2 unique chars in there add keys and
                // positions as long as there are less than 2 unique chars keep adding until the if
                // block is triggered
                charPositionMap[currChar] = head;

                if (charPositionMap.Count == 3)
                {
                    // update max
                    max = Math.Max(max, head - tail);

                    /*
                        since we are storing by index and we basically need to remove the leftmost value
                        we have to get the 'min index' in the values collection to remove

                        ex: for 'leeeeeeeetcode' the dict in UNORDERED and looks like:

                        k   |   v
                        ---------
                        l       0
                        e       8
                        t       9

                        The point is that the values aren't guaranteed to be in the order they were added, so we need to sort
                        the values and get the min out of them to get the leftmost index to remove

                     */
                    KeyValuePair<char, int> toRemove = charPositionMap.OrderBy(kvp => kvp.Value).First();
                    // evict the leftmost index
                    charPositionMap.Remove(toRemove.Key);

                    // update tail
                    tail = toRemove.Value + 1;
                }
            }

            return Math.Max(max, s.Length - tail);
        }

        public int LengthOfLongestSubstringTwoDistinct2(string s)
        {
            if (s.Length < 3) return s.Length;

            int head = 0;
            int tail = 0;
            int max = 2;
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            while (head < s.Length)
            {
                char currentChar = s[head];
                // keep adding until we exceed the threshold note we are storing the index of the
                // char rather than a count (ex of count approach https://leetcode.com/problems/find-all-anagrams-in-a-string/discuss/92007/sliding-window-algorithm-template-to-solve-all-the-leetcode-substring-search-problem)
                charIndexMap[currentChar] = head;
                head++;

                // just above the threshold
                if (charIndexMap.Count == 3)
                {
                    // get the key to remove
                    KeyValuePair<char, int> kvp = charIndexMap.OrderBy(kv => kv.Value).First();

                    // remove
                    charIndexMap.Remove(kvp.Key);

                    // update tail
                    tail = kvp.Key + 1;
                }
                // update max
                max = Math.Max(max, head - tail);
            }

            return max;
        }
    }
}