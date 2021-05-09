using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lc_2021_01
{
    public class InterviewParallaxVolatility
    {
        public static string Replace(string s)
        {
            // codility prob 2
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            StringBuilder sb = new StringBuilder(s);
            sb.Replace("plus", "+").Replace("minus", "-");
            return sb.ToString();
        }

        public static int MinimizeDifference(int[] A, int K)
        {
            // Codility problem 3
            // https://www.geeksforgeeks.org/minimize-difference-between-maximum-and-minimum-array-elements-by-removing-a-k-length-subarray/

            // convert array to list

            List<int> workingList = A.ToList();
            int range = K;


            int i = 0;
            int j = i + K - 1;
            int minSoFar = int.MaxValue;
            List<int> sublist = new List<int>();
            while (j < A.Length)
            {
                sublist.Clear();

                sublist.AddRange(workingList.GetRange(i, K));

                workingList.RemoveRange(i, range);
                int diff = workingList.Max() - workingList.Min();
                minSoFar = Math.Min(minSoFar, diff);
                workingList.InsertRange(i, sublist);

                i++;
                j++;
            }

            return minSoFar;

        }

        public bool solution(int N, int[] A, int[] B)
        {
            // codility 3 https://www.geeksforgeeks.org/find-if-there-is-a-path-between-two-vertices-in-a-given-graph/
            // https://www.geeksforgeeks.org/find-if-there-is-a-path-between-two-vertices-in-an-undirected-graph/
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return false;
        }

    }
}