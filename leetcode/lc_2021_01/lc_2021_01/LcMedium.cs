using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace lc_2021_01
{
    public class LcMedium
    {
        private readonly List<string> results = new List<string>();

        /// <summary>
        /// 17. Letter Combinations of a Phone Number https://leetcode.com/problems/letter-combinations-of-a-phone-number/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>

        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits == string.Empty) return results;

            Dictionary<char, List<char>> store = new Dictionary<char, List<char>>
            {
                {'2', new List<char>() {'a', 'b', 'c'}},
                {'3', new List<char>() {'d', 'e', 'f'}},
                {'4', new List<char>() {'g', 'h', 'i'}},
                {'5', new List<char>() {'j', 'k', 'l'}},
                {'6', new List<char>() {'m', 'n', 'o'}},
                {'7', new List<char>() {'p', 'q', 'r', 's'}},
                {'8', new List<char>() {'t', 'u', 'v'}},
                {'9', new List<char>() {'w', 'x', 'y', 'z'}}
            };

            LetterCombinationsHelper(digits, 0, new StringBuilder(), store);

            return results;
        }

        private void LetterCombinationsHelper(string digits, int i, StringBuilder current, Dictionary<char, List<char>> store)
        {
            if (i == digits.Length) results.Add(current.ToString());
            else
                foreach (char item in store[digits[i]])
                {
                    current.Append(item);

                    LetterCombinationsHelper(digits, i + 1, current, store);

                    current.Remove(current.Length - 1, 1);
                }
        }

        /// <summary>
        /// 11. Container With Most Water https://leetcode.com/problems/container-with-most-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            /*
             * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

               Notice that you may not slant the container.

            Input: height = [1,8,6,2,5,4,8,3,7]
               Output: 49
               Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

               Example 2:

               Input: height = [1,1]
               Output: 1

               Example 3:

               Input: height = [4,3,2,1,4]
               Output: 16

               Example 4:

               Input: height = [1,2,1]
               Output: 2

               Constraints:

               n == height.length
               2 <= n <= 105
               0 <= height[i] <= 104

             */

            int area = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int currentArea = GetArea(right - left, Math.Min(height[left], height[right]));
                area = Math.Max(currentArea, area);

                if (height[left] < height[right]) left++; // could be taller columns to the right
                else right--; // could be taller columns to the left
            }

            return area;
        }

        private int GetArea(int width, int height)
        {
            return width * height;
        }

        /// <summary>
        /// 39. Combination Sum https://leetcode.com/problems/combination-sum/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<List<int>> CombinationSum(int[] candidates, int target)
        {
            /*
             * Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

               The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

               It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

               Example 1:

               Input: candidates = [2,3,6,7], target = 7
               Output: [[2,2,3],[7]]
               Explanation:
               2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
               7 is a candidate, and 7 = 7.
               These are the only two combinations.

               Example 2:

               Input: candidates = [2,3,5], target = 8
               Output: [[2,2,2,2],[2,3,3],[3,5]]

               Example 3:

               Input: candidates = [2], target = 1
               Output: []

               Example 4:

               Input: candidates = [1], target = 1
               Output: [[1]]

               Example 5:

               Input: candidates = [1], target = 2
               Output: [[1,1]]

             */

            List<List<int>> results = new List<List<int>>();
            CombinationSumHelper(candidates, target, new List<int>(), results);
            return results;
        }

        public void CombinationSumHelper(int[] candidates, int target, List<int> current, List<List<int>> results)
        {
            if (target == 0) results.Add(new List<int>(current));
            foreach (int item in candidates)
            {
                current.Add(item);
                CombinationSumHelper(candidates, target - item, current, results);
                current.RemoveAt(current.Count - 1);
            }
        }

        /// <summary>
        /// 77. Combinations https://leetcode.com/problems/combinations/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static List<List<int>> Combine(int n, int k)
        {
            /*
             * Given two integers n and k, return all possible combinations of k numbers out of the range [1, n].
               You may return the answer in any order.

               Example 1:

               Input: n = 4, k = 2
               Output:
               [
               [2,4],
               [3,4],
               [2,3],
               [1,2],
               [1,3],
               [1,4],
               ]

               Example 2:

               Input: n = 1, k = 1
               Output: [[1]]

             */

            List<List<int>> combineResults = new List<List<int>>();
            CombineHelper(n, k, 1, new List<int>(), combineResults);

            return combineResults;
        }

        private static void CombineHelper(int n, int k, int start, List<int> resultsSoFar, List<List<int>> combineResults)
        {
            if (resultsSoFar.Count == k)
            {
                combineResults.Add(new List<int>(resultsSoFar));
                Console.WriteLine(JsonSerializer.Serialize(combineResults));
            }

            for (int i = start; i <= n; i++)
            {
                resultsSoFar.Add(i);
                CombineHelper(n, k, i + 1, resultsSoFar, combineResults);
                resultsSoFar.RemoveAt(resultsSoFar.Count - 1);
            }
        }
    }
}