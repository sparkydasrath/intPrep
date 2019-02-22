using System;
using System.Collections.Generic;
using System.Linq;

namespace Strings
{
    public class LongestSubstringWithAtMostKDistinctCharacters
    {
        /*
         340. Longest Substring with At Most K Distinct Characters https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
        Hard

        Given a string, find the length of the longest substring T that contains at most k distinct characters.

        Example 1:

        Input: s = "eceba", k = 2
        Output: 3
        Explanation: T is "ece" which its length is 3.

        Example 2:

        Input: s = "aa", k = 1
        Output: 2
        Explanation: T is "aa" which its length is 2.

         */

        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            /*
             * use the same window technique used in the LongestSubstringWithAtMostTwoDistinctCharacters problem
*/
            if (s.Length < k + 1) return s.Length;

            int head = 0;
            int tail = 0;
            int max = 1;

            Dictionary<char, int> charToIndexMap = new Dictionary<char, int>();
            while (head < s.Length)
            {
                char key = s[head];
                charToIndexMap[key] = head;
                head++;

                // ex if k = 2, we want to trigger this part when the dictionary count just exceeded
                // k, so always k + 1
                if (charToIndexMap.Count == k + 1)
                {
                    // key to remove
                    KeyValuePair<char, int> toRemove = charToIndexMap.OrderBy(kvp => kvp.Value).First();

                    // remove
                    charToIndexMap.Remove(toRemove.Key);

                    // update tail
                    tail = toRemove.Key + 1;
                }

                // update max
                max = Math.Max(max, head - tail);
            }

            return max;
        }
    }
}