using System;

namespace Arrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RotateMatrix rm = new RotateMatrix();

            int[,] m = MatrixUtils.BuildSquareMatrix(4);

            Console.WriteLine("---------------------");

            rm.Rotate(m);

            Console.ReadLine();
        }
    }
}