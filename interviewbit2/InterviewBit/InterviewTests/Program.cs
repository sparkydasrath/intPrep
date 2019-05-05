using InterviewTests.Blackstone;
using System;
using System.Collections.Generic;

namespace InterviewTests
{
    internal class Program
    {
        private static List<List<char>> results = new List<List<char>>();

        private bool[] visited;

        public void Combine(string s)
        {
            Console.WriteLine("----------");
            results.Clear();
            CombineHelper(s, new List<char>(), 0);
        }

        public void CombineHelper(string s, List<char> accumulator, int next)
        {
            results.Add(accumulator);

            for (int i = next; i < s.Length; i++)
            {
                accumulator.Add(s[i]);
                CombineHelper(s, new List<char>(accumulator), next + 1);
                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        public void Permute(string s)
        {
            visited = new bool[s.Length];
            results.Clear();
            PermuteHelper(s, new List<char>());
        }

        public void PermuteHelper(string s, List<char> accumulator)
        {
            if (accumulator.Count == s.Length)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (visited[i]) continue;

                accumulator.Add(s[i]);
                visited[i] = true;

                PermuteHelper(s, new List<char>(accumulator));

                accumulator.RemoveAt(accumulator.Count - 1);
                visited[i] = false;
            }
        }

        private static void Main(string[] args)
        {
            // Program p = new Program(); p.Permute("abc");
            //
            // foreach (var r in results) Console.WriteLine(string.Join("", r));
            //
            // p.Combine("abc"); foreach (var r in results) Console.WriteLine(string.Join("", r));

            Dictionary<int, int> d = new Dictionary<int, int>(64);
            // d[1] = 1; d[2] = 1; d[3] = 1; d[4] = 1; d[5] = 1; d[6] = 1; d[7] = 1; d[8] = 1;

            var x = new Denominations().DefaultDenominations;

            x.Add(200m, "two hun");
            x.Remove(200m);

            Console.ReadLine();
        }
    }
}