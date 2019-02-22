using System;
using System.Collections.Generic;

namespace Strings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HashSet<int> hs = new HashSet<int>
            {
                1,
                1
            };

            Console.WriteLine(hs.Count);
            Console.ReadLine();
        }
    }
}