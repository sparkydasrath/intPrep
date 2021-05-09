using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace lc_2021_01
{
    public static class DynamicRecursive
    {
        // https://www.youtube.com/watch?v=oBt53YbR9Kk

        public static bool IsPresent(int[] arr, int target)
        {
            // check if there are some numbers in the array that add up to the target
            return IsPresentHelper(arr, target, new Dictionary<int, bool>());
        }

        private static bool IsPresentHelper(int[] arr, int target, Dictionary<int, bool> memo)
        {
            if (memo.ContainsKey(target)) return memo[target];
            if (target == 0) return true;
            if (target < 0) return false;
            foreach (int num in arr)
            {
                int diff = target - num;
                if (IsPresentHelper(arr, diff, memo))
                {
                    memo[target] = true;
                    return true;
                }
            }

            memo[target] = false;
            return false;
        }

        public static void HowSum(int[] arr, int target)
        {
            /*
             * Function should return an array containing any combination that
             * adds up to target sum
             */

            List<int> results1 = HowSumHelper(arr, target);
            List<int> results2 = HowSumHelperWithMemo(arr, target, new Dictionary<int, List<int>>());

            Console.WriteLine(JsonSerializer.Serialize(results1));
            Console.WriteLine(JsonSerializer.Serialize(results2));
        }

        private static List<int> HowSumHelper(int[] arr, int target)
        {
            if (target == 0) return new List<int>();
            if (target < 0) return null;

            foreach (int num in arr)
            {
                int diff = target - num;
                List<int> result = HowSumHelper(arr, diff);
                if (result != null)
                {
                    result.Add(num);
                    return result;
                }
            }

            return null;
        }

        public static List<List<int>> HowSumAllPossibleCombos(int[] arr, int target)
        {
            List<List<int>> results = new();
            HowSumHelperAllPossibleCombosHelper(arr, target, new List<int>(), results);
            Console.WriteLine($"HowSumAllPossibleCombos = {JsonSerializer.Serialize(results)}");
            return results;
        }

        private static void HowSumHelperAllPossibleCombosHelper(int[] arr, int target, List<int> currentBranch, List<List<int>> results)
        {
            if (target == 0) results.Add(new List<int>(currentBranch));
            if (target < 0) return;

            foreach (int num in arr)
            {
                currentBranch.Add(num);
                int diff = target - num;
                HowSumHelperAllPossibleCombosHelper(arr, diff, currentBranch, results);
                currentBranch.RemoveAt(currentBranch.Count - 1);
            }
        }

        private static List<int> HowSumHelperWithMemo(int[] arr, int target, Dictionary<int, List<int>> memo)
        {
            if (memo.ContainsKey(target)) return memo[target];
            if (target == 0)
            {
                Console.WriteLine();
                return new List<int>();
            }
            if (target < 0) return null;

            foreach (int num in arr)
            {
                int diff = target - num;
                List<int> remainderResult = HowSumHelperWithMemo(arr, diff, memo);
                if (remainderResult != null)
                {
                    List<int> result = remainderResult.Select(x => x).ToList();
                    result.Add(num);
                    memo[target] = result;
                    return result;
                }
            }

            memo[target] = null;
            return null;
        }

        public static List<int> BestSum(int[] arr, int target)
        {
            /*
             * Return a list containing the shortest combination of numbers that add up to the target
             * If there is a tie, return any
             * ex: nums = [5 3 4 7], target = 7
             *  can generate 7 using: [3 4] and [7] so the answer is [7]
             */

            if (target == 0) return new List<int>();
            if (target < 0) return null;

            List<int> shortestCombo = null;

            foreach (int num in arr)
            {
                int diff = target - num;
                List<int> result = BestSum(arr, diff);
                if (result != null)
                {
                    List<int> combined = result.Select(x => x).ToList();
                    combined.Add(num);
                    if (shortestCombo == null || combined.Count < shortestCombo.Count)
                    {
                        shortestCombo = combined;
                    }
                }
            }

            return shortestCombo;
        }

        public static bool CanConstruct(string[] wordBank, string target)
        {
            /*
             * The function should return a bool indicating whether or not the
             * target can be constructed by concatenating elements of the wordBank array
             * Can reuse elements of wordBank
             */

            // base case - empty string since you can take 0 elements out of wordBank to get it
            // the idea is to just remove strings from the wordBank from the target until you get to empty string

            if (target == string.Empty) return true;

            foreach (string word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    string suffix = target.Substring(word.Length);
                    if (CanConstruct(wordBank, suffix)) return true;
                }
            }

            return false;
        }
    }
}