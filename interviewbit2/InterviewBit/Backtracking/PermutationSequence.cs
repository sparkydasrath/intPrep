using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class PermutationSequence
    {
        /*
         60. Permutation Sequence https://leetcode.com/problems/permutation-sequence/
        Medium

        The set [1,2,3,...,n] contains a total of n! unique permutations.

        By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

            "123"
            "132"
            "213"
            "231"
            "312"
            "321"

        Given n and k, return the kth permutation sequence.

        Note:

            Given n will be between 1 and 9 inclusive.
            Given k will be between 1 and n! inclusive.

        Example 1:

        Input: n = 3, k = 3
        Output: "213"

        Example 2:

        Input: n = 4, k = 9
        Output: "2314"
         */

        private readonly IList<IList<int>> results = new List<IList<int>>();

        public string GetPermutation(int n, int k)
        {
            bool[] visited = new bool[n];
            List<int> accumulator = new List<int>();
            int[] nums = Enumerable.Range(1, n).ToArray();
            GetPermutationHelper(nums, accumulator, visited, k, 0);
            /*
             was getting timeout, so best thing is to just permute up to the kth item then break out of everything
             */
            string result = string.Join("", results[k - 1]);
            return result;
        }

        private void GetPermutationHelper(int[] nums, List<int> accumulator, bool[] visited, int k, int kthCount)
        {
            if (accumulator.Count == nums.Length)
            {
                results.Add(new List<int>(accumulator));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    accumulator.Add(nums[i]);
                    visited[i] = true;
                    GetPermutationHelper(nums, new List<int>(accumulator), visited, k, kthCount + 1);
                    accumulator.RemoveAt(accumulator.Count - 1);
                    visited[i] = false;
                    // if (kthCount == k) return;
                }
            }
        }
    }
}