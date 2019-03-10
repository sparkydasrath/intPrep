namespace Backtracking
{
    public class WildcardMatching
    {
        /*
         44. Wildcard Matching https://leetcode.com/problems/wildcard-matching/
        Hard

        Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.

        '?' Matches any single character.
        '*' Matches any sequence of characters (including the empty sequence).

        The matching should cover the entire input string (not partial).

        Note:

            s could be empty and contains only lowercase letters a-z.
            p could be empty and contains only lowercase letters a-z, and characters like ? or *.

        Example 1:

        Input:
        s = "aa"
        p = "a"
        Output: false
        Explanation: "a" does not match the entire string "aa".

        Example 2:

        Input:
        s = "aa"
        p = "*"
        Output: true
        Explanation: '*' matches any sequence.

        Example 3:

        Input:
        s = "cb"
        p = "?a"
        Output: false
        Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.

        Example 4:

        Input:
        s = "adceb"
        p = "*a*b"
        Output: true
        Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".

        Example 5:

        Input:
        s = "acdcb"
        p = "a*c?b"
        Output: false

        tushar: https://www.youtube.com/watch?v=3ZDZ-N0EPV0
        https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/WildCardMatching.java
         */

        public bool IsMatch(string s, string p)
        {
            // https://leetcode.com/problems/wildcard-matching/discuss/17811/My-three-C%2B%2B-solutions-(iterative-(16ms)-and-DP-(180ms)-and-modified-recursion-(88ms))
            int sLen = s.Length;
            int pLen = p.Length;
            int i;
            int j;
            int iStar = -1;
            int jStar = -1;

            for (i = 0, j = 0; i < sLen; i++, j++)
            {
                if (j < pLen && p[j] == '*')
                {
                    //meet a new '*', update traceback i/j info
                    iStar = i;
                    jStar = j;
                    i--;
                }
                else
                {
                    if (j >= pLen || s[i] != p[j] && p[j] != '?')
                    {
                        // mismatch happens
                        if (iStar >= 0)
                        { // met a '*' before, then do traceback
                            i = iStar++;
                            j = jStar;
                        }
                        else return false; // otherwise fail
                    }
                }
            }
            while (j < pLen && p[j] == '*') j++;
            return j == pLen;
        }

        public bool IsMatchDfs(string s, string p)
        {
            int result = IsMatchDfsHelper(s, p, 0, 0);
            return result > 1;
        }

        public int IsMatchDfsHelper(string s, string p, int si, int pi)
        {
            // taken from https://leetcode.com/problems/wildcard-matching/discuss/17839/C%2B%2B-recursive-solution-16-ms

            // return value:
            // 0: reach the end of s but unmatched
            // 1: unmatched without reaching the end of s
            // 2: matched

            int sLen = s.Length;
            int pLen = p.Length;

            if (si == sLen && pi == pLen) return 2; // match
            if (si == sLen && p[pi] != '*') return 0; //  reach the end of s but unmatched
            if (pi == pLen) return 1; // unmatched without reaching the end of s

            if (s[si] == p[pi] || p[pi] == '?')
                return IsMatchDfsHelper(s, p, si + 1, pi + 1);

            if (p[pi] == '*')
            {
                if (pi + 1 > pLen && p[pi + 1] == '*')
                    return IsMatchDfsHelper(s, p, si, pi + 1); // skip consecutive *

                for (int i = 0; i <= sLen - si; i++)
                {
                    int ret = IsMatchDfsHelper(s, p, si + i, pi + 1);
                    if (ret == 0 || ret == 2) return ret;
                    /*
                     NOTE:
                     The purpose of ret==0 is that:
                        Suppose i = 0, you start at si and pi.
                        If the backtrack cannot find any matching, then it is meaningless to continue the for loop.
                        If you cannot find a matching start from si,
                            then how could you possibly find a matching starting from si+1?

                 */
                }
            }

            return 1;
        }

        public bool IsMatchDp(string s, string p)
        {
            /*
                 Fucking DP problem. Setting up, understanding and deriving the conditions to fill each slot
                 fucking sucks ass. Without the video I wouldn't have a fucking clue what to do.
                 How is satan's asshole are you supposed to ever answer these problems in interviews is beyond me

                 The idea is to create the 2d matrix, T, and on top set up the pattern and the right the string

                 from tushar's video

                 s = "xaylmz"
                 p = "x?y*z"

                                 0     1   2   3   4   5
                              | null | x | ? | y | * | z |
                         ----------------------------------
                     0   null |  T   | F | F | F | F | F |
                         -----|------|---|---|--------------
                     1      x |  F   | T | F | F
                         -----|------|---|------------------
                     2      a |  F   | F |
                         -----|------|---|------------------
                     3      y |  F
                         -----------------------------------

                     case 1: if s[i] != p[j] ==> T[i,j] = F

                     // the indexing is confusing here but that is because we need to reserve the
                     // first row and col for base cases, so all indices are staggered
                     case 2: if s[i-1] == p[j-1] OR p[j-1] == '?'
                             T[i,j] = T[i-1, j-1] // get value from diagonal
                             // that is because the chars either match or if the pattern is ? we can
                             // use any char

                     case 3: if p[j-1] == '*'
                             T[i,j] = T[i-1, j] OR T[i, j-1] // get value from left or top

                  * */

            bool[,] T = new bool[s.Length + 1, p.Length + 1];

            T[0, 0] = true; //empty pattern matches with empty string
            for (int col = 1; col < p.Length; col++)
            {
                if (p[col] == '*') T[0, col] = true;  //empty string matches with * in pattern
            }

            for (int row = 1; row < s.Length; row++)
            {
                for (int col = 1; col < p.Length; col++)
                {
                    // need to stagger the index in the string when looking at the chars or we will
                    // be out of range by the time we get to the end this is because we are starting
                    // our iteration at 1, but need to check s[0] first

                    if (s[row - 1] == p[col - 1] || p[col - 1] == '?')
                        T[row, col] = T[row - 1, col - 1]; // get from diagonal
                    else if (p[col - 1] == '*')
                    {
                        T[row, col] = T[row - 1, col] || /* get from prev row */
                                      T[row, col - 1];   /* get from prev col */
                    }
                }
            }

            return T[T.GetLength(0) - 1, T.GetLength(1) - 1];
        }
    }
}