using System;
using System.Collections.Generic;

namespace lc_2021_01
{
    public class LcEasy
    {
        /// <summary>
        /// 7. Reverse Integer https://leetcode.com/problems/reverse-integer/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            long result = 0;
            while (x != 0)
            {
                result *= 10;
                result += x % 10;
                x /= 10;
            }
            return (result > int.MaxValue || result < int.MinValue) ? 0 : (int)result;

            /*List<int> reversed = new List<int>();
            while (x != 0)
            {
                int mod = x % 10;
                int rem = x / 10;
                reversed.Add(mod);
                x = rem;
            }

            int exp = reversed.Count - 1;
            int sum = 0;
            foreach (int num in reversed)
            {
                sum += num * (int)Math.Pow(10, exp--);
            }

            int re = sum - int.MaxValue;

            return sum - int.MaxValue < 0 ? 0: sum;*/
        }

        /// <summary>
        /// 9. Palindrome Number https://leetcode.com/problems/palindrome-number/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int rev = Reverse(x);
            return x == rev;
        }

        /// <summary>
        /// 13. Roman to Integer https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            /*
             *Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

               Symbol       Value
               I             1
               V             5
               X             10
               L             50
               C             100
               D             500
               M             1000

               For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

               Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

               I can be placed before V (5) and X (10) to make 4 and 9.
               X can be placed before L (50) and C (100) to make 40 and 90.
               C can be placed before D (500) and M (1000) to make 400 and 900.

               Given a roman numeral, convert it to an integer.

               Example 1:

               Input: s = "III"
               Output: 3

               Example 2:

               Input: s = "IV"
               Output: 4

               Example 3:

               Input: s = "IX"
               Output: 9

               Example 4:

               Input: s = "LVIII"
               Output: 58
               Explanation: L = 50, V= 5, III = 3.

               Example 5:

               Input: s = "MCMXCIV"
               Output: 1994
               Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

             *
             */

            Dictionary<char, int> map = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            if (string.IsNullOrWhiteSpace(s)) return 0;
            if (s.Length == 1) return map[s[0]];

            int sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length)
                {
                    char currChar = s[i];
                    char nextChar = s[i + 1];
                    if (map[currChar] >= map[nextChar])
                        sum += map[currChar];
                    else
                    {
                        sum += (map[nextChar] - map[currChar]);
                        i++;
                    }
                }
                else
                    sum += map[s[i]];
            }

            return sum;
        }

        /// <summary>
        /// 14. Longest Common Prefix https://leetcode.com/problems/longest-common-prefix/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            /*
             *
             *Example 1:

               Input: strs = ["flower","flow","flight"]
               Output: "fl"

               Example 2:

               Input: strs = ["dog","racecar","car"]
               Output: ""
               Explanation: There is no common prefix among the input strings.

             *
             */

            string prefixString = "";
            if (strs == null || strs.Length == 0) return prefixString;
            if (strs.Length == 1) return strs[0];

            // Go through all the letters of the first word
            for (int i = 0; i < strs[0].Length; i++)
            {
                // Go through each of the remaining words
                foreach (string str in strs)
                {
                    // If i is higher then the length of the word
                    // there is no longer a prefix to match
                    if (i > str.Length - 1)
                        return prefixString;

                    // If the i-th letter of the string doesn't match the i-th
                    // letter of the first word we've reached the end of the
                    // common prefix
                    if (strs[0][i] != str[i])
                        return prefixString;
                }

                // If we make it through the inner foreach all of the
                prefixString += strs[0][i];
            }

            return prefixString;
        }

        /// <summary>
        /// 20. Valid Parentheses https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' && stack.Count != 00 && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (c == ']' && stack.Count != 00 && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (c == '}' && stack.Count != 00 && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else return false;
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicatesFromSortedArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;

            int head = 1;
            int tail = 0;
            while (head < nums.Length)
            {
                if (nums[tail] == nums[head]) head++;
                else
                {
                    tail++;
                    nums[tail] = nums[head];
                    head++;
                }
            }

            return ++tail;
        }

        /// <summary>
        /// 53. Maximum Subarray https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxSumSubArray(int[] nums)
        {
            /*
             *Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

               Example 1:

               Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
               Output: 6
               Explanation: [4,-1,2,1] has the largest sum = 6.

               Example 2:

               Input: nums = [1]
               Output: 1

               Example 3:

               Input: nums = [5,4,-1,7,8]
               Output: 23

               Constraints:

               1 <= nums.length <= 3 * 10^4
               -10^5 <= nums[i] <= 10^5

               Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
             *
             */

            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            // Kadane's Algo/windowing  https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/

            int maxSoFar = int.MinValue;
            int maxEndingHere = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                maxEndingHere += nums[i];
                if (maxSoFar < maxEndingHere) maxSoFar = maxEndingHere;
                if (maxEndingHere < 0) maxEndingHere = 0;
            }
            return maxSoFar;
        }

        /// <summary>
        /// 58. Length of Last Word https://leetcode.com/problems/length-of-last-word/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            string[] split = s.Trim().Split(" ");
            return split[^1].Length;
        }

        /// <summary>
        /// 70. Climbing Stairs https://leetcode.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs(int n)
        {
            /*
             * You are climbing a staircase. It takes n steps to reach the top.

               Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

               Example 1:

               Input: n = 2
               Output: 2
               Explanation: There are two ways to climb to the top.
               1. 1 step + 1 step
               2. 2 steps

               Example 2:

               Input: n = 3
               Output: 3
               Explanation: There are three ways to climb to the top.
               1. 1 step + 1 step + 1 step
               2. 1 step + 2 steps
               3. 2 steps + 1 step

             */

            /*if (n < 0) return 0;
            if (n == 0) return 1;
            return ClimbStairs(n - 1) + ClimbStairs(n - 2);*/
            return ClimbStairsWithMemo(n, new Dictionary<int, int>());
        }

        public static int ClimbStairsWithMemo(int n, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(n)) return memo[n];

            if (n < 0) return 0;
            if (n == 0) return 1;
            int result = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            memo[n] = result;
            return result;
        }

        public static int ClimbStairsDp(int n)
        {
            if (n == 0 || n == 1) return 1;

            int[] result = new int[n + 1];
            result[0] = result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[result.Length - 1];
        }

        /// <summary>
        /// 111. Minimum Depth of Binary Tree https://leetcode.com/problems/minimum-depth-of-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            /*
             * Given a binary tree, find its minimum depth.
               The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
               Note: A leaf is a node with no children.
             */

            if (root == null) return 0;
            if (root.Left == null) return MinDepth(root.Right) + 1;
            if (root.Right == null) return MinDepth(root.Left) + 1;
            return Math.Min(MinDepth(root.Left), MinDepth(root.Right)) + 1;

        }

        /// <summary>
        /// 112. Path Sum https://leetcode.com/problems/path-sum/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            /*
             * Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
               
               A leaf is a node with no children.
             */

            if (root == null) return false;
            if (root.Left == null && root.Right == null && targetSum == (int)root.Value) return true;
            return HasPathSum(root.Left, targetSum - (int)root.Value) || HasPathSum(root.Right, targetSum - (int)root.Value);
        }
    }
}