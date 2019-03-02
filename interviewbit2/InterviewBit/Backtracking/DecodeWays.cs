using System;
using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class DecodeWays
    {
        /*
         * 91. Decode Ways https://leetcode.com/problems/decode-ways/
        Medium

        A message containing letters from A-Z is being encoded to numbers using the following mapping:

        'A' -> 1
        'B' -> 2
        ...
        'Z' -> 26

        Given a non-empty string containing only digits, determine the total number of ways to decode it.

        Example 1:

        Input: "12"
        Output: 2
        Explanation: It could be decoded as "AB" (1 2) or "L" (12).

        Example 2:

        Input: "226"
        Output: 3
        Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

         */
        private List<string> decodings = new List<string>();
        private int numDecodings = 0;

        public int NumDecodings(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            int result;
            result = NumDecodingsDfs(s, 0);
            return result;
        }

        public int NumDecodings2(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            // NumDecodingsDfs2(s, new StringBuilder());
            NumDecodingsDfs3(s, "");
            return numDecodings;
        }

        public int NumDecodings3(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            NumDecodingsDfs3(s, "");
            return numDecodings;
        }

        private int NumDecodingsDfs(string s, int pos)
        {
            if (pos < s.Length && s[pos] == '0') return 0;

            if (pos == s.Length)
            {
                // we have reached the leaf node of the tree
                return 1;
            }

            /* if we are not at the end, we need to branch and
                choose either 1 char or 2 chars
             */

            // choose 1 char
            int numWays = NumDecodingsDfs(s, pos + 1);

            int decodedValue = 0;

            /* check if we can have enough chars left to select two at the same time
                that is, when pos + 2 does not exceed the length of the string
             */
            if (pos + 1 < s.Length)
            {
                string ss = s.Substring(pos, pos + 1);
                decodedValue = Convert.ToInt32(ss);
            }

            if (decodedValue >= 10 && decodedValue <= 26)
                numWays += NumDecodingsDfs(s, pos + 2);

            return numWays;
        }

        private void NumDecodingsDfs2(string s, StringBuilder results)
        {
            /* base case, keep removing from the string based on number of chars chosen
                our branching condition is to
                1. pick one char
                2. pick two chars

            stop the recursion once we have exhausted the string
             */

            if (string.IsNullOrEmpty(s))
            {
                // we hit the end of the recursion stack
                numDecodings += 1;
                decodings.Add(results.ToString());
                return;
            }

            // as long as we can take one char at a time, lets try to take it
            results.Append(s.Substring(0, 1) + " ");
            NumDecodingsDfs2(s.Substring(1), results);
            results.Remove(results.Length - 1, 1);

            if (s.Length >= 2)
            {
                // once we exhaust all 1 char options and start to backtrack up the recursion stack
                // try to take two chars and see if we can decode them
                string temp = s.Substring(0, 2);
                // lets check if two chars are can be decoded correctly
                int twoCharDecoded = Convert.ToInt32(temp);
                if (twoCharDecoded >= 10 && twoCharDecoded <= 26)
                {
                    results.Append(s.Substring(0, 2) + " ");
                    NumDecodingsDfs2(s.Substring(2), results);
                    results.Remove(results.Length - 1, 1);
                }
            }
        }

        private void NumDecodingsDfs3(string s, string results)
        {
            /* base case, keep removing from the string based on number of chars chosen
                our branching condition is to
                1. pick one char
                2. pick two chars

            stop the recursion once we have exhausted the string
             */

            if (string.IsNullOrEmpty(s))
            {
                // we hit the end of the recursion stack
                numDecodings += 1;
                decodings.Add(results.ToString());
                return;
            }

            // as long as we can take one char at a time, lets try to take it
            results += (s.Substring(0, 1) + " ");
            NumDecodingsDfs3(s.Substring(1), results);
            results.Remove(results.Length - 1, 1);

            if (s.Length >= 2)
            {
                // once we exhaust all 1 char options and start to backtrack up the recursion stack
                // try to take two chars and see if we can decode them
                string temp = s.Substring(0, 2);
                // lets check if two chars are can be decoded correctly
                int twoCharDecoded = Convert.ToInt32(temp);
                if (twoCharDecoded >= 10 && twoCharDecoded <= 26)
                {
                    results += (s.Substring(0, 2) + " ");
                    NumDecodingsDfs3(s.Substring(2), results);
                    results.Remove(results.Length - 1, 1);
                }
            }
        }
    }
}