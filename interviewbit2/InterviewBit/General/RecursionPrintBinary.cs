using System;
using System.Collections.Generic;
using System.Text;

namespace General
{
    public class RecursionPrintBinary
    {
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

        public static void PrintBinaryIterative(int n)
        {
            Stack<int> s = new Stack<int>();

            while (true)
            {
                int div = n / 2;
                int rem = n % 2;
                s.Push(rem);
                n = div;
                if (div == 0) break;
            }

            StringBuilder sb = new StringBuilder();
            while (s.Count != 0)
                sb.Append(s.Pop());

            Console.WriteLine(sb.ToString());
        }
    }
}