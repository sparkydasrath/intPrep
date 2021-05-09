using System;

namespace lc_2021_01
{
    public static class LcEasyRunner
    {
        public static void RunLongestCommonPrefix()
        {
            Console.WriteLine(LcEasy.LongestCommonPrefix(new[] { "flower", "flow", "flight" }) + " expected fl");
            Console.WriteLine(LcEasy.LongestCommonPrefix(new[] { "flower", "flower", "flower", "flower" }) + " expected flower");
            Console.WriteLine(LcEasy.LongestCommonPrefix(new[] { "dog", "racecar", "car" }) + "expected empty string");
        }

        public static void RunIsValid()
        {
            Console.WriteLine(LcEasy.IsValid("()[]{}"));
            Console.WriteLine(LcEasy.IsValid("([)]"));
        }

        public static void RunRemoveDuplicatesFromSortedArray()
        {
            Console.WriteLine(LcEasy.RemoveDuplicatesFromSortedArray(new int[] { 1, 1, 2 }) + " Expecting 2");
            Console.WriteLine(LcEasy.RemoveDuplicatesFromSortedArray(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }) + " Expecting 5");
        }

        public static void RunMaxSumSubArray()
        {
            Console.WriteLine(LcEasy.MaxSumSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }) + " Expecting 6");
            Console.WriteLine(LcEasy.MaxSumSubArray(new int[] { 1 }) + " Expecting 1");
            Console.WriteLine(LcEasy.MaxSumSubArray(new int[] { 5, 4, -1, 7, 8 }) + " Expecting 23");
        }

        public static void RunLengthOfLastWord()
        {
            Console.WriteLine(LcEasy.LengthOfLastWord("Hello World") + " Expecting 5");
            Console.WriteLine(LcEasy.LengthOfLastWord("a ") + " Expecting 1");
            Console.WriteLine(LcEasy.LengthOfLastWord("    day ") + " Expecting 3");
        }

        public static void RunClimbStairs()
        {
            /*int results1 = LcEasy.ClimbStairs(2);
            Console.WriteLine($"Wants to climb 2 stairs = {results1}");

            int results2 = LcEasy.ClimbStairs(3);
            Console.WriteLine($"Wants to climb 3 stairs = {results2}");

            int results3 = LcEasy.ClimbStairs(4);
            Console.WriteLine($"Wants to climb 4 stairs with Memoization = {results3}");*/

            int results4 = LcEasy.ClimbStairsDp(4);
            Console.WriteLine($"Wants to climb 4 stairs with DP = {results4}");
        }

        public static void RunRomanToInt()
        {
            Console.WriteLine("result: " + LcEasy.RomanToInt("III") + " and expected: 3");
            Console.WriteLine("result: " + LcEasy.RomanToInt("IV") + " and expected: 4");
            Console.WriteLine("result: " + LcEasy.RomanToInt("IX") + " and expected: 9");
            Console.WriteLine("result: " + LcEasy.RomanToInt("XXXIV") + " and expected: 34");
            Console.WriteLine("result: " + LcEasy.RomanToInt("LVIII") + " and expected: 58");
            Console.WriteLine("result: " + LcEasy.RomanToInt("MCMXCIV") + " and expected: 1994");
        }
    }
}