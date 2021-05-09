using System;
using System.Collections.Generic;

namespace lc_2021_01
{
    public static class BinarySearchRunner
    {
        public static void Run()
        {
            Console.WriteLine("Binary Search");
            List<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BinarySearch search = new();
            int is5Present = search.IsPresent(list, 5);
            int is10Present = search.IsPresent(list, 10);

            Console.WriteLine($"Is 5 present: {is5Present}");
            Console.WriteLine($"Is 10 present: {is10Present}");
        }
    }
}