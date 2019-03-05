using System.Collections.Generic;

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
            bool[] visited = new bool[s1.Length];
            List<string> accumulator = new List<string>();
            CheckInclusionHelper(s1, accumulator, visited);
            foreach (string result in results)
            {
                if (s2.Contains(result)) return true;
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
    }
}