using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class CombinationSum
    {
        private IList<IList<int>> results = new List<IList<int>>();

        public IList<IList<int>> CombinationSum1(int[] candidates, int target)
        {
            /*
             39. Combination Sum https://leetcode.com/problems/combination-sum/
            Medium

            Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

            The same repeated number may be chosen from candidates unlimited number of times.

            Note:

                All numbers (including target) will be positive integers.
                The solution set must not contain duplicate combinations.

            Example 1:

            Input: candidates = [2,3,6,7], target = 7,
            A solution set is:
            [
              [7],
              [2,2,3]
            ]

            Example 2:

            Input: candidates = [2,3,5], target = 8,
            A solution set is:
            [
              [2,2,2,2],
              [2,3,3],
              [3,5]
            ]

             */
            results.Clear();
            List<int> accumulator = new List<int>();
            CombinationSumHelper1(candidates, target, accumulator, 0);
            return results;
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            /*
             * 40. Combination Sum II
            Medium

            Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

            Each number in candidates may only be used once in the combination.

            Note:

                All numbers (including target) will be positive integers.
                The solution set must not contain duplicate combinations.

            Example 1:

            Input: candidates = [10,1,2,7,6,1,5], target = 8,
            A solution set is:
            [
              [1, 7],
              [1, 2, 5],
              [2, 6],
              [1, 1, 6]
            ]

            Example 2:

            Input: candidates = [2,5,2,1,2], target = 5,
            A solution set is:
            [
              [1,2,2],
              [5]
            ]

             */
            results.Clear();
            List<int> accumulator = new List<int>();
            CombinationSumHelper2(candidates, target, accumulator, 0);
            return results;
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            /*
             216. Combination Sum III https://leetcode.com/problems/combination-sum-iii/
            Medium

            Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

            Note:

                All numbers will be positive integers.
                The solution set must not contain duplicate combinations.

            Example 1:

            Input: k = 3, n = 7
            Output: [[1,2,4]]

            Example 2:

            Input: k = 3, n = 9
            Output: [[1,2,6], [1,3,5], [2,3,4]]

             */

            results.Clear();
            int[] nums = Enumerable.Range(1, 9).ToArray();
            List<int> accumulator = new List<int>();
            CombinationSumHelper3(nums, n, accumulator, 0, k);
            return results;
        }

        private void CombinationSumHelper1(int[] candidates, int target, List<int> accumulator, int start)
        {
            if (accumulator.Sum() == target)
            {
                results.Add(accumulator);
                return;
                ;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target)
                    CombinationSumHelper1(candidates, target, new List<int>(accumulator), i);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        private void CombinationSumHelper2(int[] candidates, int target, List<int> accumulator, int start)
        {
            //combo sum 2
            // see LC
            if (accumulator.Sum() == target)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target)
                    CombinationSumHelper1(candidates, target, new List<int>(accumulator), i + 1);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        private void CombinationSumHelper3(int[] candidates, int target, List<int> accumulator, int start, int k)
        {
            if (accumulator.Sum() == target && accumulator.Count == k)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target && accumulator.Count <= k)
                    CombinationSumHelper1(candidates, target, new List<int>(accumulator), i + 1);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }
    }
}