using System.Collections.Generic;

namespace Facebook
{
    public class FindAllAnagramsInString
    {
        /*
         438. Find All Anagrams in a String https://leetcode.com/problems/find-all-anagrams-in-a-string/
        Easy

        Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

        Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

        The order of output does not matter.

        Example 1:

        Input:
        s: "cbaebabacd" p: "abc"

        Output:
        [0, 6]
        Explanation:
        The substring with start index = 0 is "cba", which is an anagram of "abc".
        The substring with start index = 6 is "bac", which is an anagram of "abc".

        Example 2:

        Input:
        s: "abab" p: "ab"

        Output:
        [0, 1, 2]
        Explanation:
        The substring with start index = 0 is "ab", which is an anagram of "ab".
        The substring with start index = 1 is "ba", which is an anagram of "ab".
        The substring with start index = 2 is "ab", which is an anagram of "ab".

         */

        public List<int> FindAnagrams(string s, string t)
        {
            List<int> result = new List<int>();
            // following the template https://leetcode.com/problems/find-all-anagrams-in-a-string/discuss/92007/sliding-window-algorithm-template-to-solve-all-the-leetcode-substring-search-problem
            if (t.Length > s.Length) return result;
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else map[c]++;
            }

            int counter = map.Count;

            int left = 0, right = 0;

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
                    char leftChar = s[left];
                    if (map.ContainsKey(leftChar))
                    {
                        map[leftChar]++;
                        if (map[leftChar] > 0)
                        {
                            counter++;
                        }
                    }
                    if (right - left == t.Length)
                    {
                        result.Add(left);
                    }
                    left++;
                }
            }

            return result;
        }
    }
}