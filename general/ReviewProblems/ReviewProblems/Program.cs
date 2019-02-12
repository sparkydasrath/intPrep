using System;

namespace ReviewProblems
{
    internal class Program
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length < 2)
            {
                return true;
            }

            char first = s[0];
            char last = s[s.Length - 1];
            if (first == last)
            {
                string rest = s.Substring(1, s.Length - 1 - 1);
                return IsPalindrome(rest);
            }

            return false;
        }

        public static int Power(int x, int n)
        {
            if (n == 0) return x;
            return x * Power(x, n - 1);
        }

        public static void PrintBinary(int n)
        {
            // mine if (n == 0) return;

            if (n < 2)
                Console.WriteLine(n);
            else
            {
                int x = n / 2;
                int y = n % 2;
                Console.WriteLine(y);
                PrintBinary(x);
            }
        }

        private static void Main(string[] args)
        {
            // linq playground List<int> list = new List<int> { 1, 5, 10, 11, 6, 3 }; int[] arr =
            // new[] { 1, 5, 10, 11, 6, 3 };
            //
            // int[] res = arr.Where(x => x > 10).Select(x => x).ToArray();

            // recursion playground int result = Power(2, 4);
            //
            // bool isPalindrome = IsPalindrome("madam");
            PrintBinary(43);
            Console.ReadLine();
        }
    }
}