using System;

namespace Arrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] a = new[] { 1, 2 };
            int z = 0;
            foreach (int i in a)
            {
                int result = i * 2;
                Console.WriteLine(result);
                a[z] = result;
                z++;
            }

            Console.ReadLine();
        }
    }
}