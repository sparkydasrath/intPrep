using System.Collections.Generic;

namespace Arrays
{
    public class FindTheTownJudge
    {
        /*
         997. Find the Town Judge https://leetcode.com/problems/find-the-town-judge/
        Easy

        In a town, there are N people labelled from 1 to N.  There is a rumor that one of these people is secretly the town judge.

        If the town judge exists, then:

            The town judge trusts nobody.
            Everybody (except for the town judge) trusts the town judge.
            There is exactly one person that satisfies properties 1 and 2.

        You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.

        If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.

        Example 1:

        Input: N = 2, trust = [[1,2]]
        Output: 2

        Example 2:

        Input: N = 3, trust = [[1,3],[2,3]]
        Output: 3

        Example 3:

        Input: N = 3, trust = [[1,3],[2,3],[3,1]]
        Output: -1

        Example 4:

        Input: N = 3, trust = [[1,2],[2,3]]
        Output: -1

        Example 5:

        Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
        Output: 3

        Note:

            1 <= N <= 1000
            trust.length <= 10000
            trust[i] are all different
            trust[i][0] != trust[i][1]
            1 <= trust[i][0], trust[i][1] <= N

         */

        public int FindJudge(int N, int[][] trust)
        {
            // LC https://leetcode.com/problems/find-the-town-judge/discuss/247328/C-100-with-explanationcomments
            /*
            Time - O(T+N) where T is the trust.Length
            Space - O(N)
            */

            // if there is only 1 person (N=1) or trust is empty, then the person is the town judge.
            if (N == 1 || trust.Length == 0) return 1;

            int[] truster = new int[N + 1]; // first element of trust array
            int[] trustee = new int[N + 1]; // second element of trust array - person being trusted

            for (int i = 0; i < trust.Length; i++)
            {
                truster[trust[i][0]]++;
                trustee[trust[i][1]]++;
            }

            // to satisfy to be the town judge: trustee of index j must be total number of
            // people(N)-1 truster of index j must be 0
            for (int j = 0; j < trustee.Length; j++)
            {
                if (trustee[j] == N - 1 && truster[j] == 0) return j;
            }

            return -1;
        }

        public int FindJudge2(int N, int[][] trust)
        {
            /*
                go over each pair and add the first element to a Dictionary with a count of how many people this person knows
                take another pass over N and see who in the dictionary has a count of zero - this is the mayor
                if everyone is in the dictionary with a count >= 1, return -1
            */

            Dictionary<int, int> candidates = new Dictionary<int, int>();
            for (int i = 0; i < trust.Length; i++)
            {
                int[] pair = trust[i];
                if (!candidates.ContainsKey(pair[0]))
                {
                    candidates[pair[0]] = 1;
                    continue;
                }

                candidates[pair[0]]++;
            }

            int mayor = -1;
            for (int i = 1; i <= N; i++)
            {
            }

            return mayor;
        }
    }
}