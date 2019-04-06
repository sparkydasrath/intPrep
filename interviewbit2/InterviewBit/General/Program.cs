using System;
using System.Collections.Concurrent;

namespace General
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BacktrackingPermute.Permute("abc");

            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

            Console.ReadLine();
        }
    }
}