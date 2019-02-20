using System;
using System.Collections.Generic;

namespace Permutations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Permutations1 p1 = new Permutations1();
            List<List<int>> r = p1.Permute(new int[] { 1, 2, 3 });

            Console.ReadLine();
        }
    }
}