using System;
using System.Collections.Generic;

namespace Strings
{
    public class LongestSubstringWithoutRepeatingChars
    {
        /*
         * https://leetcode.com/problems/longest-substring-without-repeating-characters/
         *
         * Given a string, find the length of the longest substring without repeating characters.

           Example 1:

           Input: "abcabcbb"
           Output: 3
           Explanation: The answer is "abc", with the length of 3.

           Example 2:

           Input: "bbbbb"
           Output: 1
           Explanation: The answer is "b", with the length of 1.

           Example 3:

           Input: "pwwkew"
           Output: 3
           Explanation: The answer is "wke", with the length of 3.
           Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

         */

        public bool AllUnique(string s, int start, int end)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = start; i < end; i++)
            {
                char ch = s[i];
                if (set.Contains(ch)) return false;
                set.Add(ch);
            }
            return true;
        }

        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j <= n; j++)
                    if (AllUnique(s, i, j)) ans = Math.Max(ans, j - i);
            return ans;
        }

        public int LengthOfLongestSubstringUsingDictionary(string s)
        {
            int n = s.Length;
            int ans = 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }
            return ans;
        }

        public int LengthOfLongestSubstringWithSetAsSlidingWindow(string s)
        {
            // use a sorted set as the sliding window
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    j++;
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
            }
            return ans;
        }
    }
}