using System;

namespace General
{
    public class BacktrackingPrintAllBinary
    {
        public static void PrintAllBinary(int n) =>
            // https://www.youtube.com/watch?v=Frr8U5_TTtg&list=PLT0wqqmbAFnfdRRCnzqY943MDyaNa3KSy&index=9&t=0s
            // permuation, backtracking print all binary numbers that have exactly n number of digits
            /**
             * ex: n = 2
             * 00
             * 01
             * 10
             * 11
             */
            PrintAllBinaryHelper(3, "");


        private static void PrintAllBinaryHelper(int digits, string output)
        {
            if (digits == 0)
            {
                Console.WriteLine(output);
            }
            else
            {
                PrintAllBinaryHelper(digits - 1, output + "0");
                PrintAllBinaryHelper(digits - 1, output + "1");
            }
        }
    }
}