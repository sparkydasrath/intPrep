using System;
using System.Linq;

namespace General
{
    public class RecursionDecodeWays
    {
        public int DecodeDp(string s)
        {
            /*https://www.youtube.com/watch?v=aCKyFYF9_Bg
            *https://github.com/IDeserve/learn/blob/master/EncodeDecode.java
             * https://www.geeksforgeeks.org/count-possible-decodings-given-digit-sequence/
            */

            if (s.Length == 0 || s[0] == '0') return 0;

            if (s.Length == 0 || s.Length == 1) return 1;

            /*
             * ok so it looks like just using counts isn't going to work
             * so will try the dp approach
             * int count = 0;
             */

            int[] dp = new int[s.Length + 1];
            // means that empty string and single char strings can be decoded only one way
            dp[0] = 1;
            dp[1] = 1;

            /*
             * the idea is that starting at i=2 (so in 226, i is pointing to 6)
             * look at the one char before 6 - it's 2. Since its not 0, it contributes to
             *  the current count
             *
             * look at two chars before 6 and see if together (22) they form a valid code
             */

            for (int i = 2; i <= s.Length; i++)
            {
                // check single char case
                if (s[i - 1] > '0') dp[i] += dp[i - 1];

                // check 2 char case

                if (s[i - 2] == '1' || s[i - 2] == '2' && s[i - 1] < '7') dp[i] += dp[i - 2];
            }

            return dp.Last();
        }

        public int NumDecodings(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            int result;
            result = NumDecodingsDfs(s, 0);
            return result;
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
    }
}