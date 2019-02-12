using System;

namespace General
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RecursionDecodeWays dw = new RecursionDecodeWays();
            int res = dw.NumDecodings("226");

            Console.ReadLine();
        }
    }
}