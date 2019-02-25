using System;

namespace Strings
{
    public class EditDistance
    {
        public int EditDistanceOrLevenshteinDistance(string s, string t)
        {
            /*
            72. Edit Distance https://leetcode.com/problems/edit-distance/
            Hard

            Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.

            You have the following 3 operations permitted on a word:

            Insert a character
            Delete a character
            Replace a character

            Example 1:

            Input: word1 = "horse", word2 = "ros"
            Output: 3
            Explanation:
            horse -> rorse (replace 'h' with 'r')
            rorse -> rose (remove 'r')
            rose -> ros (remove 'e')

            Example 2:

            Input: word1 = "intention", word2 = "execution"
            Output: 5
            Explanation:
            intention -> inention (remove 't')
            inention -> enention (replace 'i' with 'e')
            enention -> exention (replace 'n' with 'x')
            exention -> exection (replace 'n' with 'c')
            exection -> execution (insert 'u')

            LC: solution https://leetcode.com/articles/edit-distance/#
            Another  https://people.cs.pitt.edu/~kirk/cs1501/Pruhs/Spring2006/assignments/editdistance/Levenshtein%20Distance.htm

            vivek: https://www.youtube.com/watch?v=b6AGUjqIPsA
            tushar: https://www.youtube.com/watch?v=We3YDTzNXEk

            hamming distance:
                both words have to be the same length
                only allowed substitutions (min# of substitutions needed to turn string 1 to string 2)

        */

            // This is the GENERALIZED way of doing it via dp

            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            int[,] dp = new int[s.Length + 1, t.Length + 1];

            // fill up the first row
            for (int row = 0; row < dp.GetLength(0); row++)
                dp[row, 0] = row;

            // fill up the first col
            for (int col = 0; col < dp.GetLength(1); col++)
                dp[0, col] = col;

            int cost;

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                char charInS = s[row - 1];
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    char charInT = t[col - 1];

                    if (charInS == charInT) cost = 0;
                    else cost = 1;

                    int left = dp[row, col - 1]; // left to right = insert
                    int top = dp[row - 1, col]; // top to next row = remove/delete
                    int diag = dp[row - 1, col - 1]; // replace

                    dp[row, col] = cost + MinOfThree(left, top, diag);
                }
            }

            return dp[s.Length, t.Length];
        }

        public bool IsOneEditDistance(string s, string t)
        {
            // https://leetcode.com/problems/one-edit-distance/discuss/50170/2ms-Java-solution-with-explanation

            // this removes difference between character insertion and removal
            if (s.Length > t.Length) return IsOneEditDistance(t, s);

            // If difference in lengths is greater than 1, it cannot be IsOneEditDistance
            if (t.Length - s.Length > 1) return false;

            int i = 0;
            while (i < s.Length)
            {
                if (s[i] != t[i])
                {
                    // If the length is different rest of string s including this character should
                    // match since unmatched character in string t would account for one edit
                    // (i.e.deletion) distance. If on the other hand if length is same, current
                    // character in string s would account for one edit (i.e. substitution distance,
                    // and hence rest of the string needs to be matched.
                    return s.Substring(i + 1) == t.Substring(i + 1) || s.Substring(i) == t.Substring(i + 1);
                }
                i++;
            }

            // code reaching here implies, prefixes of two strings are same. Now if length is equal
            // it would imply zero edit distance and hence should return false.
            return s.Length + 1 == t.Length;
        }

        private int MinOfThree(int a, int b, int c) => Math.Min(a, Math.Min(b, c));
    }
}