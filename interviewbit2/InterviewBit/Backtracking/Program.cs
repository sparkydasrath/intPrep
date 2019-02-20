using System;

namespace Backtracking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HeapsAlgorithm ha = new HeapsAlgorithm();

            int[] a = { 1, 1, 2, 3 };
            ha.PermuteUsingHeapsAlgorithm(a, a.Length, a.Length);
            Console.ReadLine();
        }
    }
}