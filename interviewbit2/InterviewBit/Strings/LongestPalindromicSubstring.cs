using System.Linq;

namespace Strings
{
    public class LongestPalindromicSubsequence
    {
        // DYNAMIC PROGRAMMING
        /* This is a fucking hard problem to just pull out of your ass during an interview. Seriously, FUCK ME
         *https://www.youtube.com/watch?v=yZWmS6CXbQc
         *
         */
    }

    public class LongestPalindromicSubstring
    {
        // DYNAMIC PROGRAMMING

        /*https://leetcode.com/problems/longest-palindromic-substring/
         *
         * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

           Example 1:

           Input: "babad"
           Output: "bab"
           Note: "aba" is also a valid answer.

           Example 2:

           Input: "cbbd"
           Output: "bb"

         */

        public string GetLongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            if (s.Length == 1) return s;

            if (string.Equals(s, new string(s.Reverse().ToArray()))) return s;

            // this solution is O(n^2) (potentially n^3 due to linq operations)
            string palindrome = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] != s[j]) continue;

                    string potentialPalindrome = s.Substring(i, j + 1 - i);
                    string reversed = new string(potentialPalindrome.Reverse().ToArray());
                    bool isPal = string.Equals(potentialPalindrome, reversed);

                    if (isPal && potentialPalindrome.Length > palindrome.Length) palindrome = potentialPalindrome;
                    // else j++;
                }
            }

            return palindrome == string.Empty ? s[0].ToString() : palindrome;
        }
    }
}