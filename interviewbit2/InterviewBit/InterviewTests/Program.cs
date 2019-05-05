using System;
using System.Collections.Generic;
using System.IO;
using InterviewTests.Blackstone;

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
            string l1 = string.Empty;
            string l2 = string.Empty;

            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Question3 q3 = new Question3();
                    var result = q3.GetChange(line);
                    Console.WriteLine(result);
                }
        }
    }
}