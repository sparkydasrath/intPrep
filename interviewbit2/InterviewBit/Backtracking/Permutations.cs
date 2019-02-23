﻿using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Backtracking
{
    public class Permutations
    {
        /*
            Following Tushar's https://www.youtube.com/watch?v=nYFd7VHKyWQ&feature=youtu.be guide

            Permutation with repeated characters but the output is unique (does not repeat permutations generated by the repeated chars)

            Algorithm:
            1. For input string, create a count array
                ex: aabc

                char   count
            --------------------
                a       2
                b       1
                c       1
            2. Create result array which is the input string's length
            3. Go from left to right and look for the first available char
                3a. A char is available if it's count > 0
            4. Put that char in the corresponding position in the result array
                NOTE: The position/index into the array is determined by the depth of the recursion
            5. Decrement the count (since we used it for the current step) and recurse
            6. When you return from the recursion, you restore the count and
                and then look for the next available character that has count > 0
         */

        private readonly Dictionary<char, int> map;
        private Tuple<char[], int[]> charCountPair;
        private char[] result;

        public Permutations()
        {
            map = new Dictionary<char, int>();
            AllResults = new List<string>();
        }

        public List<string> AllResults { get; }

        public void PermuteWithModifyInputDfs(string s)
        {
            List<string> output = new List<string>();
            PermuteWithModifyInputDfsHelper(s, output);
        }

        public void PermuteWithModifyInputDfsHelper(string s, List<string> output)
        {
            // Console.WriteLine($"permute s={s}, output={ListUtils.PrintToString(output)}"); base case
            if (s.Length == 0)
            {
                ListUtils.PrintToConsole(output);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    // choose
                    char c = s[i];
                    output.Add(c.ToString());
                    string nextChoices = s.Remove(i, 1);

                    // explore
                    PermuteWithModifyInputDfsHelper(nextChoices, output);

                    // un-choose basically undo what you did in the choose section
                    output.Remove(c.ToString());
                    string result = s.Insert(i, c.ToString());
                    // Console.WriteLine($"Inserting back result & s = {result}, {s}");
                }
            }
        }

        public void PermuteWithoutModifyInputDfs(string s)
        {
            // see LetterPhoneNumbers in this project for an example
        }

        public void PermuteWithRepeatedCharsBase(string input)
        {
            // assume that s is already sorted so we are getting aabc

            // create count array
            foreach (char c in input)
            {
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else map[c] += 1;
            }

            // create two arrays representing the above mapping of char to count
            charCountPair = GetCharAndCountArrayFromMap(map);

            // create result array
            result = new char[input.Length];

            PermuteWithRepeatedCharsDfs(charCountPair.Item1, charCountPair.Item2, result, 0);
        }

        public List<List<int>> PermuteWithVisitedArrayDfs(int[] nums)
        {
            /*
        * 46. Permutations  https://leetcode.com/problems/permutations/
        *
        * Given a collection of distinct integers, return all possible permutations.

           Example:

           Input: [1,2,3]
           Output:
           [
             [1,2,3],
             [1,3,2],
             [2,1,3],
             [2,3,1],
             [3,1,2],
             [3,2,1]
           ]

               see also Backtracking.Permute for the first run of this
                   NOTE: this approach was modifying the input with each recursion

               in this version, I will aim to do DFS using the ideas from the graph section of marking each node/array slot as 'visited'

            *
        */
            if (nums.Length == 0) return null;
            List<List<int>> results = new List<List<int>>();
            List<int> accumulator = new List<int>();
            bool[] visited = new bool[nums.Length];
            PermuteWithVisitedArrayDfsHelper(nums, results, accumulator, visited, 0);

            return results;
        }

        private Tuple<char[], int[]> GetCharAndCountArrayFromMap(Dictionary<char, int> dict)
        {
            // create two arrays representing the above mapping of char to count
            char[] str = new char[dict.Count];
            int[] counts = new int[dict.Count];
            int index = 0;
            foreach (KeyValuePair<char, int> kvp in dict)
            {
                str[index] = kvp.Key;
                counts[index] = kvp.Value;
                index++;
            }

            return new Tuple<char[], int[]>(str, counts);
        }

        private void PermuteWithRepeatedCharsDfs(char[] input, int[] counts, char[] output, int depth)
        {
            // base case
            if (depth == output.Length)
            {
                // print out whatever is in the result array
                PrintArray(output);
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                // 3. Go from left to right and look for the first available char 3a. A char is
                // available if it's count > 0
                if (counts[i] == 0) continue;

                // 4. Put that char in the corresponding position in the result array
                // NOTE: The position/ index into the array is determined by the depth of the recursion
                result[depth] = input[i];

                // 5. Decrement the count (since we used it for the current step) and recurse
                counts[i]--;

                PermuteWithRepeatedCharsDfs(input, counts, result, depth + 1);

                // 6.When you return from the recursion, you restore the count and and then look for
                // the next available character that has count > 0
                counts[i]++;
            }
        }

        private void PermuteWithVisitedArrayDfsHelper(int[] nums, List<List<int>> results, List<int> accumulator, bool[] visited, int recursionDepth)
        {
            if (accumulator.Count == nums.Length)
            {
                // checking for 0 because we are removing elements from this list
                results.Add(accumulator);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    // choose an item/node in the list that has not been visited to begin exploring
                    // from and add it to the result set
                    accumulator.Add(nums[i]);
                    visited[i] = true;
                    // recurse
                    PermuteWithVisitedArrayDfsHelper(nums, results, new List<int>(accumulator), visited, recursionDepth + 1);

                    // un-choose
                    accumulator.Remove(nums[i]);
                    visited[i] = false;
                    // go back up one level
                    recursionDepth--;
                }
            }
        }

        private void PrintArray(char[] res)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in res)
                sb.Append(c);
            AllResults.Add(sb.ToString());
        }
    }
}