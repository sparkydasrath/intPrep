using System.Collections.Generic;

namespace Arrays
{
    public class FindTheCelebrity
    {
        /*
        277. Find the Celebrity
        Medium

        Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, there may exist one celebrity. The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.

        Now you want to find out who the celebrity is or verify that there is not one. The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible (in the asymptotic sense).

        You are given a helper function bool knows(a, b) which tells you whether A knows B. Implement a function int findCelebrity(n). There will be exactly one celebrity if he/she is in the party. Return the celebrity's label if there is a celebrity in the party. If there is no celebrity, return -1.

        Example 1:

        Input: graph = [
          [1,1,0],
          [0,1,0],
          [1,1,1]
        ]
        Output: 1
        Explanation: There are three persons labeled with 0, 1 and 2. graph[i][j] = 1 means person i knows person j, otherwise graph[i][j] = 0 means person i does not know person j. The celebrity is the person labeled as 1 because both 0 and 2 know him but 1 does not know anybody.

        Example 2:

        Input: graph = [
          [1,0,1],
          [1,1,0],
          [0,1,1]
        ]
        Output: -1
        Explanation: There is no celebrity.

        Note:

            The directed graph is represented as an adjacency matrix, which is an n x n matrix where a[i][j] = 1 means person i knows person j while a[i][j] = 0 means the contrary.
            Remember that you won't have direct access to the adjacency matrix.

         */

        public int FindCelebrity(int n)
        {
            // best explanation https://leetcode.com/problems/find-the-celebrity/discuss/144815/Logical-Thinking-with-Clear-Java-Code
            /*

            It is inductive that we can find the candidate and check whether it is up to standard or not.

            How do we decide the candidate?
            We are sure that if A knows B, A cannot be the celebrity while B may be, i.e., B is the candidate. Since there is only one celebrity, one loop is enough to decide the candidate.

            How do we check whether the candidate is up to standard?
            According to the definition of a celebrity, if !knows(i, candidate) || knows(candidate, i) exists, the candidate is not qualified.
             */

            int candidate = 0;
            for (int i = 1; i < n; i++)
            {
                if (Knows(candidate, i))
                    candidate = i;
            }
            for (int i = 0; i < n; i++)
            {
                if (i == candidate) continue;
                if (!Knows(i, candidate) || Knows(candidate, i))
                    return -1;
            }
            return candidate;
        }

        public int FindCelebrity2(int n)
        {
            int knowsCount = 0;
            List<int> counts = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (Knows(i, j)) knowsCount++;

                if (knowsCount == 1) counts.Add(i);
                knowsCount = 0;
            }

            if (counts.Count == 1) return counts[0];
            return -1;
        }

        private bool Knows(int a, int b) => true;
    }
}