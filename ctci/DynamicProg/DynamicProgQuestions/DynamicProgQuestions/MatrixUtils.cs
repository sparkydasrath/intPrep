using System;

namespace DynamicProgQuestions
{
    public static class MatrixUtils
    {
        public static void Print(int[,] m)
        {
            int rowLength = m.GetLength(0);
            int colLength = m.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}