using System.Collections.Generic;

namespace Facebook
{
    public class MinimumWindowSubstring
    {
        /*
         76. Minimum Window Substring https://leetcode.com/problems/minimum-window-substring/
        Hard

        Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

        Example:

        Input: S = "ADOBECODEBANC", T = "ABC"
        Output: "BANC"

        Note:

            If there is no such window in S that covers all characters in T, return the empty string "".
            If there is such window, you are guaranteed that there will always be only one unique minimum window in S.

        https://www.youtube.com/watch?v=9odu9ImG9oY
        https://www.youtube.com/watch?v=FB7hinjq_KY

         */

        public string MinWindow(string s, string t)
        {
            // https://leetcode.com/problems/minimum-window-substring/
            /*
                use the sliding window pattern + dictionary to keep track of all the chars we need (string t is what we have to match) and
                another that keeps how many of t we have found in s

             */

            if (string.IsNullOrWhiteSpace(s) ||
            string.IsNullOrWhiteSpace(t) ||
            s.Length == 0 ||
            t.Length == 0 ||
            s.Length < t.Length

            )
            {
                return string.Empty;
            }

            // sliding window
            /*
                make a map of all the unique chars in the target substring, t
             */

            Dictionary<char, int> targetMap = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!targetMap.ContainsKey(c))
                    targetMap[c] = 1;
                else targetMap[c]++;
            }

            // Dictionary which keeps a count of all the unique characters in the current window.
            Dictionary<char, int> windowMap = new Dictionary<char, int>();

            //maintain a counter to check whether match the target string.
            // Number of unique characters in t, which need to be present in the desired window.
            int needed = targetMap.Count;//must be the map size, NOT the string size because the char may be duplicate.

            // formed is used to keep track of how many unique characters in t are present in the
            // current window in its desired frequency. e.g. if t is "AABC" then the window must have
            // two A's, one B and one C. Thus formed would be = 3 when all these conditions are met.
            int formed = 0;

            // initialize pointers to track window size
            int right = 0;
            int left = 0;

            // ans list of the form (window length, left, right)
            int[] ans = { -1, 0, 0 };
            while (right < s.Length)
            {
                // expand the right pointer and add the chars to the windowMap
                char c = s[right];
                if (!windowMap.ContainsKey(c))
                    windowMap[c] = 1;
                else windowMap[c]++;

                // If the frequency of the current character added equals to the desired count in t
                // then increment the formed count by 1.
                if (targetMap.ContainsKey(c) && targetMap[c] == windowMap[c])
                    formed++; // we have matched all counts of this char

                // Try and contract the window till the point where it ceases to be 'desirable'. ie.
                // move the left pointer forward and update the windowMap and the result set want to
                // move the left until this condition is false because at this point we have a valid
                // window containing all the target chars
                while (left <= right && formed == needed)
                {
                    // once we have a valid window containing all the chars in the target, update our results
                    char leftChar = s[left];
                    // Save the smallest window until now. (best to abstract this out to it's own method/type)
                    if (ans[0] == -1 || right - left + 1 < ans[0])
                    {
                        ans[0] = right - left + 1;
                        ans[1] = left;
                        ans[2] = right;
                    }

                    // to move the left counter forward, need to remove this char from the windowMap
                    windowMap[leftChar]--;

                    // once we remove a char, we have to update the formed count
                    if (targetMap.ContainsKey(leftChar) && windowMap[leftChar] < targetMap[leftChar])
                    {
                        formed--;
                    }
                    // Move the left pointer ahead, this would help to look for a new window.
                    left++;
                }
                // Keep expanding the window once we are done contracting.
                right++;
            }

            return ans[0] == -1 ? "" : s.Substring(ans[1], ans[0]);
        }

        public string MinWindow2(string s, string t)
        {
            // following the template https://leetcode.com/problems/find-all-anagrams-in-a-string/discuss/92007/sliding-window-algorithm-template-to-solve-all-the-leetcode-substring-search-problem
            if (t.Length > s.Length) return "";
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else map[c]++;
            }

            int counter = map.Count;

            int left = 0, right = 0;
            int head = 0; // keeps track of where the substring that has all of string t start
            int minLength = int.MaxValue;

            while (right < s.Length)
            {
                char c = s[right];
                if (map.ContainsKey(c))
                {
                    // decrement count of char & update
                    map[c]--;
                    if (map[c] == 0)
                    {
                        // this means we have seen one char in the string that is also in the target
                        // string so decrement the counter
                        counter--;
                    }
                }
                right++;

                while (counter == 0)
                {
                    // this means we have found all the chars in t in the current window we are
                    // looking at
                    char leftChar = s[left];
                    if (map.ContainsKey(leftChar))
                    {
                        // if the left pointer is a char that is in the target map, we need to add it
                        // back in because we will be shifting the window to the right otherwise it
                        // would stay counted as found which is wrong
                        map[leftChar]++;
                        if (map[leftChar] > 0)
                        {
                            counter++;
                        }
                    }
                    if (right - left < minLength)
                    {
                        minLength = right - left;
                        head = left;
                    }
                    left++;
                }
            }
            if (minLength == int.MaxValue) return "";
            return s.Substring(head, minLength);
        }
    }
}