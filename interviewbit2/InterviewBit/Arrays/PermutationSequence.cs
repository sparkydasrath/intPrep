using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    public class PermutationSequence
    {
        // TIMEOUT EXCEEDED on LC - I did this the brute force way

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
            // best explanation https://leetcode.com/problems/permutation-sequence/discuss/22507/%22Explain-like-I'm-five%22-Java-Solution-in-O(n)

            List<int> nums = Enumerable.Range(1, n).ToList();

            int[] factorial = new int[n + 1];
            StringBuilder sb = new StringBuilder();

            // create an array of factorial lookup
            int sum = 1;
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
                factorial[i] = sum;
                // factorial[] = {1, 1, 2, 6, 24, ... n!}
            }

            // make k one less to deal with zero indexing of lists
            k--;

            for (int i = 1; i <= n; i++)
            {
                int index = k / factorial[n - i];
                sb.Append(nums[index]);
                nums.RemoveAt(index);
                k -= index * factorial[n - i];
            }

            return string.Empty;
        }

        public string GetPermutation_TimelimitExceeded(int n, int k)
        {
            bool[] visited = new bool[n];
            List<int> accumulator = new List<int>();
            int[] nums = Enumerable.Range(1, n).ToArray();
            GetPermutationHelper(nums, accumulator, visited);
            /*
             was getting timeout, so best thing is to just permute up to the kth item then break out of everything
             */
            string result = string.Join("", results[k - 1]);
            return result;
        }

        private void GetPermutationHelper(int[] nums, List<int> accumulator, bool[] visited)
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
                    GetPermutationHelper(nums, new List<int>(accumulator), visited);
                    accumulator.RemoveAt(accumulator.Count - 1);
                    visited[i] = false;
                }
            }
        }
    }
}