using System;

namespace Arrays
{
    public static class MatrixUtils
    {
        public static int[,] BuildSquareMatrix(int size)
        {
            int[,] m = new int[size, size];
            int val = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m[i, j] = val++;
                }
            }

            Print(m);
            return m;
        }

        public static void Print(int[,] m)
        {
            int rowLength = m.GetLength(0);
            int colLength = m.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write($"{m[i, j]}\t");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}