namespace Graphs
{
    public class NetworkDelayTime
    {
        /*
         *
         *743. Network Delay Time https://leetcode.com/problems/network-delay-time/
            Easy

            There are N network nodes, labelled 1 to N.

            Given times, a list of travel times as directed edges times[i] = (u, v, w), where u is the source node,
            v is the target node, and w is the time it takes for a signal to travel from source to target.

            Now, we send a signal from a certain node K. How long will it take for all nodes to receive the signal?
            If it is impossible, return -1.

            Note:

                N will be in the range [1, 100].
                K will be in the range [1, N].
                The length of times will be in the range [1, 6000].
                All edges times[i] = (u, v, w) will have 1 <= u, v <= N and 1 <= w <= 100.

         *  The input is given as an adjaceny matrix so something like

                   1    2    3    4
                   ___________________
                1 | 0 | 20 | 15 | 30 |
                  --------------------
                2 | 10| 0  | 33 | 80 |
                  --------------------

        so times[i, j] = times [2,4] = 80

        therefore if we are given the starting node, i, then we can just sum all elements
        in that row to get the cost of the signal originating at node i = k
         */

        public int GetNetworkDelayTime(int[,] times, int n, int k)
        {
            if (k > n) return -1;

            int sum = 0;
            int totalNodes = 1;

            for (int i = 0; i < n; i++)
            {
                // we can iterate and skip until we get to the k-th index
                if (i != k) continue;

                for (int j = 0; j < n; j++)
                {
                    // once we have found the k-th index, sum across
                    sum += times[i, j];
                    totalNodes++;
                }

                // no need to continue after summing up the k-th row
                break;
            }

            return totalNodes == n ? sum : -1;
        }
    }
}