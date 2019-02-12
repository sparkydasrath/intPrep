using System.Collections.Generic;

namespace Permutations
{
    public class Permutations1
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

        public List<List<int>> Permute(int[] nums)
        {
            if (nums.Length == 0) return null;
            List<List<int>> results = new List<List<int>>();
            List<int> accumulator = new List<int>();
            bool[] visited = new bool[nums.Length];
            PermuteHelper(nums, results, accumulator, visited, 0);

            return results;
        }

        public void PermuteHelper(int[] nums, List<List<int>> results, List<int> accumulator, bool[] visited, int recursionDepth)
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
                    PermuteHelper(nums, results, new List<int>(accumulator), visited, recursionDepth + 1);

                    // un-choose
                    accumulator.Remove(nums[i]);
                    visited[i] = false;
                    // go back up one level
                    recursionDepth--;
                }
            }
        }
    }
}