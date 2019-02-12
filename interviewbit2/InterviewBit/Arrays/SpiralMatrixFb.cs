using System.Collections.Generic;
using Utils;

namespace Arrays
{
    public class SpiralMatrixFb
    {
        /*
         * Question 1: 2D Spiral Array
           Find the pattern and complete the function:
           int[][] spiral(int n);
           where n is the size of the 2D array.

            Sample Result
           input = 3
           123
           894
           765

           input = 4
           01 02 03 04
           12 13 14 05
           11 16 15 06
           10 09 08 07

           input = 8
           1 2 3 4 5 6 7 8
           28 29 30 31 32 33 34 9
           27 48 49 50 51 52 35 10
           26 47 60 61 62 53 36 11
           25 46 59 64 63 54 37 12
           24 45 58 57 56 55 38 13
           23 44 43 42 41 40 39 14
           22 21 20 19 18 17 16 15
         */

        public int[,] GetSpiral(int n)
        {
            int[,] m = new int[n, n];
            int maxCount = n * n;
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
            MatrixUtils.PrintMatrixGeneric(m);
            return m;
        }

        public int[,] GetSpiralCounterClockwise(int n)
        {
            int[,] m = new int[n, n];
            int maxCount = n * n;
            int curVal = 0;
            int row = 0;
            int col = 0;
            int dir = 0;
            int[] dc = { 0, 1, 0, -1 }; // flip these two from the original spiral matrix
            int[] dr = { 1, 0, -1, 0 };
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
            MatrixUtils.PrintMatrixGeneric(m);
            return m;
        }

        public int PrintElementAtGivenLocationInSpiralMatrix(int[,] m, int k)
        {
            // https://www.geeksforgeeks.org/print-kth-element-spiral-form-matrix/
            int row = m.GetLength(0);
            int col = m.GetLength(1);

            if (row < 1 || col < 1) return -1;

            int r = m.GetLength(0);
            int c = m.GetLength(1);
            int result = 0;

            if (k <= r)
            {
                // in first row, so just return it
                result = m[0, k - 1];
                return result;
            }

            if (k <= r + c - 1)
            {
                // not in first row but could be in the right most column

                result = m[(k - c), c - 1];
                return result;
            }

            if (k <= r + c - 1 + r - 1)
            {
                /* in last row
                * need to find where in the last row k is
                *  	total elements in first row = c (total # of cols)
                *	total elements in last cols	= r - 1
                *	so k minus the elements in first row and last column will place it
                *		the last row: k - c + r - 1 [this mess]
                * 	however, it is in a specific column index that we need to find so do
                *		c - 1 - (this mess)
                */
                int lastRow = k - c + r - 1;
                int actualPos = c - 1 - lastRow;
                result = m[r - 1, actualPos];
                return result;
            }

            if (k <= r + c - 1 + r - 1 + c - 1)
            {
                /*
                    k element is in the first column
                    find where k is in the first col
                */
                int someK = k - c + r - 1 - c - 1; // top, right, bottom
                int pos = r - 1 - someK;
                result = m[pos, 0];
                return result;
            }

            // FAIL here cause I don't know how to recursively access the inner matrix
            return -1;
        }

        public void PrintMatrixInZigZagForm(int[,] m)
        {
            int row = 0;
            int dir = 0; // 0 = left to right, i = right to left
            List<int> result = new List<int>(m.GetLength(0) * m.GetLength(1));
            while (row < m.GetLength(0))
            {
                if (dir == 0)
                {
                    for (int i = row; i < m.GetLength(1); i++)
                    {
                        result.Add(m[row, i]);
                    }

                    row++;
                }
                else
                {
                    for (int i = m.GetLength(1) - 1; i >= 0; i--)
                    {
                        result.Add(m[row, i]);
                    }
                    row++;
                }
                dir = (dir + 1) % 2;
            }

            ListUtils.PrintToConsole(result);
        }

        public void RotateMatrix90Clockwise(int[,] a)
        {
            int n = 4;

            // Traverse each cycle
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    // Swap elements of each cycle in clockwise direction
                    int temp = a[i, j];
                    a[i, j] = a[n - 1 - j, i];
                    a[n - 1 - j, i] = a[n - 1 - i, n - 1 - j];
                    a[n - 1 - i, n - 1 - j] = a[j, n - 1 - i];
                    a[j, n - 1 - i] = temp;
                }
            }

            MatrixUtils.PrintMatrixGeneric(a);
        }

        private static bool IsValid(int[,] m, int r, int c) => r < 0 || c < 0 || r >= m.GetLength(0) || c >= m.GetLength(1) || m[r, c] != 0;
    }
}