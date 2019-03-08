using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class PermutationInString
    {
        /*
         567. Permutation in String https://leetcode.com/problems/permutation-in-string/
        Medium
        Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. In other words, one of the first string's permutations is the substring of the second string.

        Example 1:

        Input:s1 = "ab" s2 = "eidbaooo"
        Output:True
        Explanation: s2 contains one permutation of s1 ("ba").

        Example 2:

        Input:s1= "ab" s2 = "eidboaoo"
        Output: False

        Note:

            The input strings only contain lower case letters.
            The length of both given strings is in range [1, 10,000].

         */

        private IList<string> results = new List<string>();

        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            // use array instead of dictionary
            int[] s1Map = new int[26];
            foreach (char c in s1)
                s1Map[c - 'a']++;

            for (int i = 0; i <= s2.Length - s1.Length; i++)
            {
                int[] s2Map = new int[26];
                for (int j = 0; j < s1.Length; j++)
                    s2Map[s2[i + j] - 'a']++;

                if (CompareMaps(s1Map, s2Map)) return true;
            }

            return false;
        }

        public bool CheckInclusionTimeout(string s1, string s2)
        {
            bool[] visited = new bool[s1.Length];
            List<string> accumulator = new List<string>();
            CheckInclusionHelper(s1, accumulator, visited);
            foreach (string result in results)
            {
                if (s2.Contains(result)) return true;
            }

            return false;
        }

        public bool CheckInclusionv2(string s1, string s2)
        {
            // have to abandon this approach, i keep hitting edge cases

            /*
             Strategy:
             1. Iterate s1 and add each char to a dictionary keeping track of the count of each char (for repeats)
             2. For each char in s1
                 a. Iterate s2 until you find that char
                 b. Take the substring of s2 whose length is that of s1
                 c. If the length of the substring is less than s1, move on to the second char
                 d. If all chars in the substring is in the dictionary, return true
                 e. If all chars are not in the dictionary, move on to the next char in s1

             This looks to be O(s1 * s2 * s1)
                 the second s1 if for walking the substring

            LC answer: https://leetcode.com/articles/short-permutation-in-a-long-string/#
             */

            if (s1.Length > s2.Length) return false;

            // add s1 to dictionary
            Dictionary<char, int> s1Map = new Dictionary<char, int>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (!s1Map.ContainsKey(s1[i]))
                {
                    s1Map[s1[i]] = 1;
                    continue;
                }
                s1Map[s1[i]]++;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] != s2[j]) continue;

                    string substr = new string(s2.Substring(j).Take(s1.Length).ToArray());

                    if (string.IsNullOrWhiteSpace(substr) || substr.Length < s1.Length) continue;

                    for (int k = 0; k < substr.Length; k++)
                    {
                        if (!s1Map.ContainsKey(substr[k])) break;
                        s1Map[substr[k]]--;
                    }

                    if (s1Map.Values.All(v => v == 0)) return true;

                    // we need to put back the counts we removed in the prior step or else the next
                    // iteration will fail
                    for (int k = 0; k < substr.Length; k++)
                    {
                        if (s1Map.ContainsKey(substr[k]))
                            s1Map[substr[k]]++;
                    }

                    break;
                }
            }

            return false;
        }

        private void CheckInclusionHelper(string s1, List<string> accumulator, bool[] visited)
        {
            if (s1.Length == accumulator.Count)
            {
                results.Add(string.Join("", accumulator));
                return;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (!visited[i])
                {
                    accumulator.Add(s1[i].ToString());
                    visited[i] = true;
                    CheckInclusionHelper(s1, accumulator, visited);
                    accumulator.RemoveAt(accumulator.Count - 1);
                    visited[i] = false;
                }
            }
        }

        private bool CompareMaps(int[] s1Map, int[] s2Map)
        {
            for (int i = 0; i < 26; i++)
                if (s1Map[i] != s2Map[i]) return false;
            return true;
        }
    }
}