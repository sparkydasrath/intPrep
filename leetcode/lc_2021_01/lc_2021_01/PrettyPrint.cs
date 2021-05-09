using System;

namespace lc_2021_01
{
    public static class PrettyPrint
    {
        public static void Print(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}