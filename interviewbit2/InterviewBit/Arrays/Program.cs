using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    internal class Program
    {
        public static bool IsPowerOfTwo(int n)
        {
            while (n > 1 && n % 2 == 0)
            {
                n /= 2;
            }

            return n == 1;
        }

        private static void Main(string[] args)
        {
            List<int> l1 = new List<int> { 1, 6 };
            List<int> l2 = new List<int> { 2, 8 };
            List<int> l3 = new List<int> { 7, 12 };

            List<int> a = l1.Union(l2).ToList();
            List<int> b = a.Union(l3).ToList();

            Console.ReadLine();
        }
    }
}