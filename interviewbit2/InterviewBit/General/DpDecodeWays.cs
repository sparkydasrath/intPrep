using System;
using System.Linq;

namespace General
{
    public class DpDecodeWays
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

        public int DecodeDp2(string s)
        {
            /*
             * https://www.youtube.com/watch?v=cQX3yHS0cLo
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
            dp[1] = s[0] == '0' ? 0 : 1;

            /*
             * the idea is that starting at i=2 (so in 226, i is pointing to 6)
             * look at the one char before 6 - it's 2. Since its not 0, it contributes to
             *  the current count
             *
             * look at two chars before 6 and see if together (22) they form a valid code
             */

            for (int i = 2; i <= s.Length; i++)
            {
                int oneDigit = Convert.ToInt32(s.Substring(i - 1, 1));
                int twoDigit = Convert.ToInt32(s.Substring(i - 2, 2));

                // check single char case
                if (oneDigit >= 1) dp[i] += dp[i - 1];

                // check 2 char case
                if (twoDigit >= 10 && twoDigit <= 26) dp[i] += dp[i - 2];
            }

            return dp.Last();
        }
    }
}