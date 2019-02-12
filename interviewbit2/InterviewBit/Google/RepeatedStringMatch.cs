using System.Text;

namespace Google
{
    public class RepeatedStringMatch
    {
        /*
         * Repeated String Match https://leetcode.com/explore/interview/card/google/67/sql-2/469/

        Given two strings a and b, find the minimum number of times a has to be repeated such that b is a substring of it. If no such solution, return -1.

        For example, with a = "abcd" and b = "cdabcdab".

        Return 3, because by repeating a three times (“abcdabcdabcd”), b is a substring of it; and b is not a substring of a repeated two times ("abcdabcd").

        Note:
        The length of a and b will be between 1 and 10000.

         */

        public int RepeatedStringMatchProblem(string a, string b)
        {
            /*

            It is intuitive to keep repeating A until the newly built result contains B. And we do the contains check only if the length of result is no smaller than the length of B.
            The obstacle is to decide when to stop repeating if we detect that there is no such solution.
            We should stop after we try all possible starting positions of B in A.

            For example,

            Given A = abc,  B = bcabca

            result = abcabc // time to do the 'contains' check

            result = abcabcabc // can cover all possible starting positions of B in A.
                     bcabca
                      bcabca
                       bcabca

            Thus,

                when the length of result is no smaller than the length of B, we check for once.
                if that doesn't work, we append one more A to result to cover all possible starting positions of B - if that still doesn't work, it is proved that there is no such solution.

             */

            if (a.Length == 0) return -1;
            if (b.Length == 0) return 0;
            StringBuilder temp = new StringBuilder();
            temp.Append(a);
            int counter = 1;

            while (temp.Length < b.Length)
            {
                temp.Append(a);
                counter++;
            }

            if (temp.ToString().IndexOf(b) != -1) return counter;

            // add just one more instance of string a to temp and do the check again if b is not in
            // it, it will never be in it no matter how many times we append

            temp.Append(a);
            if (temp.ToString().IndexOf(b) != -1) return counter + 1;
            return -1;
        }
    }
}