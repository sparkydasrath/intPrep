using System;

namespace SearchAndSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SquareRootOfInteger s = new SquareRootOfInteger();
            double a = s.SquareRoot(11, 5);
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}