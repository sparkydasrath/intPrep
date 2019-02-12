using System;

namespace Utils
{
    public static class MatrixUtils
    {
        public static T[,] BuildMatrixGeneric<T>(int rows, int columns)
        {
            T[,] m = new T[rows, columns];
            T val = default(T);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    m[i, j] = val;
                }
            }

            PrintMatrixGeneric(m);
            return m;
        }

        public static int[,] BuildSpiralMatrix(int rows, int columns)
        {
            int[,] m = new int[rows, columns];

            int maxCount = rows * columns;
            int curVal = 0;
            int row = 0;
            int col = 0;
            int dir = 0;
            int[] dc = { 1, 0, -1, 0 };
            int[] dr = { 0, 1, 0, -1 };
            while (curVal++ < maxCount)
            {
                m[row, col] = curVal;
                MatrixUtils.PrintMatrixGeneric(m);

                row += dr[dir];
                col += dc[dir];
                if (IsValid(m, row, col))
                {
                    row -= dr[dir];
                    col -= dc[dir];
                    dir = (dir + 1) % 4;
                    row += dr[dir];
                    col += dc[dir];
                }
            }

            return m;
        }

        public static int[,] BuildSquareMatrix(int size, bool isZero = false)
        {
            int[,] m = new int[size, size];
            int val = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (isZero) m[i, j] = 0;
                    else m[i, j] = val++;
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

        public static void PrintMatrixGeneric<T>(T[,] m)
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

        private static bool IsValid(int[,] m, int r, int c) =>
            r < 0 || c < 0 || r >= m.GetLength(0) || c >= m.GetLength(1) || m[r, c] != 0;
    }
}