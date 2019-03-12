namespace Backtracking
{
    public class RegularExpressionMatching
    {
        /*
         10. Regular Expression Matching https://leetcode.com/problems/regular-expression-matching/
            Hard

            Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

            '.' Matches any single character.
            '*' Matches zero or more of the preceding element.

            The matching should cover the entire input string (not partial).

            Note:

                s could be empty and contains only lowercase letters a-z.
                p could be empty and contains only lowercase letters a-z, and characters like . or *.

            Example 1:

            Input:
            s = "aa"
            p = "a"
            Output: false
            Explanation: "a" does not match the entire string "aa".

            Example 2:

            Input:
            s = "aa"
            p = "a*"
            Output: true
            Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

            Example 3:

            Input:
            s = "ab"
            p = ".*"
            Output: true
            Explanation: ".*" means "zero or more (*) of any character (.)".

            Example 4:

            Input:
            s = "aab"
            p = "c*a*b"
            Output: true
            Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".

            Example 5:

            Input:
            s = "mississippi"
            p = "mis*is*p*."
            Output: false

            tushar: https://www.youtube.com/watch?v=3ZDZ-N0EPV0
            (10:50 into the vid does a better job explaining the more complex * matching branches)

            from the comments:

            1. if current char matches we are good
            2. If current char doesn't match , no hope
            3. if it's *, here's the crux of dp kicks in:
	            3.1 first sub structure will come when we DO NOT count
                    the char before * ( we have the memoized result for that in i,j-2)
	            3.2 second sub structure will come when when 3.1 is false and do rely
                    on the char before * ( we have memoized the result for that in i-1,j-1)
                    (if 3.1 is false, i.e, if after going 2 steps back the value in the matrix is false
                     it means we have to consider the char before *)
                    3.2.1 now check if the char before * in the pattern in the same as the char we are checking in the string
                     if true - take value from top row (T[i-1, j])
                     if false - set T[i,j] to false (14:00 in vid)
         */

        public bool IsMatch(string s, string p)
        {
            // LC https://leetcode.com/articles/regular-expression-matching/#
            if (p.Length == 0) return s.Length == 0;  //If the pattern is empty, then only an empty string can match

            //checks if current char in string is equal to current char in pattern
            bool firstMatch = !string.IsNullOrWhiteSpace(s) && (s[0] == p[0] || p[0] == '.');

            //kleene star coming up
            if (p.Length >= 2 && p[1] == '*')
            {
                bool result =
                          IsMatch(s, p.Substring(2)) /*if there are 0 occurrences of the star's preceding char, skip over it. */
                            ||
                          firstMatch && IsMatch(s.Substring(1), p); //there is an instance of the star's preceding character
                return result;
            }

            //no kleene star coming up,
            return firstMatch && IsMatch(s.Substring(1), p.Substring(1)); //since there was no star, check isFirstMatch and then rest of string
        }

        public bool IsMatchDp(string s, string p)
        {
            bool[,] T = new bool[s.Length + 1, p.Length + 1];
            T[0, 0] = true;
            // do some housekeeping to handle cases like a* or a*b* or z*b*c* (17:00)
            for (int i = 1; i < T.GetLength(0); i++)
            {
                if (p[i - 1] == '*') T[0, i] = T[0, i - 2];
            }

            for (int str = 1; str < T.GetLength(0); str++)
            {
                for (int pat = 1; pat < T.GetLength(1); pat++)
                {  /*
                    case 1: pattern is . or text and pattern matches
                    ex: s = xa, p = x. => since . matches any char, we can remove the . and a and
                    check the remaining str and pattern
                        p:     x .
                        s:   x
                             a
                 */
                    if (p[pat - 1] == '.' || s[str - 1] == p[pat - 1])
                    {
                        // get value from diagonal
                        T[str, pat] = T[str - 1, pat - 1];
                    }
                    else if (p[pat - 1] == '*')
                    {
                        /*
                            case 2a: don't consider the char that comes before *
                            just take the value from 2 columns back
                        */
                        T[str, pat] = T[str, pat - 2];

                        /*
                            case 2b: consider the char before * and see if that char in the string
                                matches with the pattern
                                if true take value from top row
                                else everything else is false
                         */

                        if (p[pat - 2] == '.' || s[str - 1] == p[pat - 2])
                        {
                            T[str, pat] = T[str, pat] | T[str - 1, pat];
                        }
                    }
                    else
                    {
                        T[str, pat] = false;
                    }
                }
            }

            return T[s.Length, p.Length];
        }

        /*
        public bool IsMatchHelper3(string s, string p, int si, int pi)
        {
            // return value:
            // 0: reach the end of s but unmatched
            // 1: unmatched without reaching the end of s
            // 2: matched
            int sLen = s.Length;
            int pLen = p.Length;
            if (si == sLen && pi == pLen) return true;
            if (si != sLen && pi == pLen) return false;
            if (si == sLen && pi != pLen) return false;
            // if the chars don't match and the next one isn't a * then this pattern is a dud
            if (pi + 1 < pLen && s[si] != p[pi] && p[pi + 1] != '*') return false;

            // match
            if (s[si] == p[pi] || p[pi] == '.')
            {
                // if the chars match or the pattern has a . then everything matched so far so
                // continue the process
                return IsMatchHelper(s, p, si, pi + 1);
            }

            if (p[pi] == '*')
            {
                /* means we have matched previous chars and now have a char/* pair
                 ex: s = aa,
                     p = a*

                    s[0]==p[0] = a  OK
                    s[1]!=p[1] = *  Need to check prev char

                 #1#

                char prevChar = p[pi - 1]; // assume happy path for now
                if (s[si] != prevChar) return false;

                // since it is a match, need to find how many chars in s can be included as part of
                // the zero or more match case
                while (si < sLen && s[si] == prevChar) si++;

                // once this is done, just try to match other chars
                return IsMatchHelper(s, p, si, pi + 1);
            }

            // if it doesn't match, check if the next char is *
            if (s[si] != p[pi] && pi < pLen && p[pi + 1] == '*')
            {
                return IsMatchHelper(s, p, si, pi + 2);
            }

            return false;
        }
*/

        /*public int IsMatchHelper2(string s, string p, int si, int pi)
        {
            // return value:
            // 0: reach the end of s but unmatched
            // 1: unmatched without reaching the end of s
            // 2: matched
            int sLen = s.Length;
            int pLen = p.Length;
            if (si == sLen && pi == pLen) return 2;
            if (si == sLen && p[pi] != '*') return 1;
            // if the chars don't match and the next one isn't a * then this pattern is a dud
            if (s[si] != p[pi] && pi < pLen && p[pi + 1] != '*') return 1;

            // match
            if (s[si] == p[pi] || p[pi] == '.')
            {
                // if the chars match or the pattern has a . then everything matched so far so
                // continue the process
                return IsMatchHelper(s, p, si + 1, pi + 1);
            }

            if (p[pi] == '*')
            {
                /* means we have matched previous chars and now have a char/* pair
                 ex: s = aa,
                     p = a*

                    s[0]==p[0] = a  OK
                    s[1]!=p[1] = *  Need to check prev char

                 #1#

                char prevChar = p[pi - 1]; // assume happy path for now
                if (s[si] != prevChar) return 1;

                // since it is a match, need to find how many chars in s can be included as part of
                // the zero or more match case
                while (si < sLen && s[si] == prevChar) si++;
                // once this is done, just try to match other chars
                return IsMatchHelper(s, p, si + 1, pi + 1);
            }

            // if it doesn't match, check if the next char is *
            if (s[si] != p[pi] && pi < pLen && p[pi + 1] == '*')
            {
                return IsMatchHelper(s, p, si, pi + 2);
            }

            return 1;
        }*/
    }
}