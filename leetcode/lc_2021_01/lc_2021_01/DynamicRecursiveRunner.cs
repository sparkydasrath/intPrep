using System;
using System.Collections.Generic;
using System.Text.Json;

namespace lc_2021_01
{
    public static class DynamicRecursiveRunner
    {
        public static void RunIsPresent()
        {
            Console.WriteLine(DynamicRecursive.IsPresent(new[] { 2, 3 }, 7));
            Console.WriteLine(DynamicRecursive.IsPresent(new[] { 5, 3, 4, 7 }, 7));
            Console.WriteLine(DynamicRecursive.IsPresent(new[] { 2, 4 }, 7));
        }

        public static void RunHowSum()
        {
            DynamicRecursive.HowSum(new[] {5, 3, 4, 7}, 7);
            DynamicRecursive.HowSum(new[] {2, 4}, 7);
        }

        public static void RunHowSumAllPossibleCombos()
        {
            DynamicRecursive.HowSumAllPossibleCombos(new[] { 5, 3, 4, 7 }, 7);
            DynamicRecursive.HowSumAllPossibleCombos(new[] { 2, 4 }, 7);

        }

        public static void RunBestSum()
        {
            List<int> a = DynamicRecursive.BestSum(new[] { 5, 3, 4, 7 }, 7);
            List<int> b = DynamicRecursive.BestSum(new[] { 2, 4 }, 7);

            Console.WriteLine($"Best sum : {JsonSerializer.Serialize(a)}; {JsonSerializer.Serialize(b)}");

        }

        public static void RunCanConstruct()
        {
            Console.WriteLine(DynamicRecursive.CanConstruct(new[] { "ab", "abc", "cd", "def", "abcd"}, "abcdef"));
            Console.WriteLine(DynamicRecursive.CanConstruct(new[] { "bo", "rd", "ate", "ska", "sk", "boar"}, "skateboard"));

        }
    }
}