using System;
using System.Collections.Generic;

namespace Backtracking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Permutations perm = new Permutations(); perm.PermuteWithRepeatedCharsBase("abc"); Console.WriteLine(perm.AllResults);

            Program p = new Program();

            Combinations c = new Combinations();
            List<List<int>> r = c.SubsetsDfs(new int[] { 1, 1, 3 });

            Console.ReadLine();
        }
    }
}