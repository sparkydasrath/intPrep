using System.Collections.Generic;

namespace Arrays
{
    public class SpiralMatrix
    {
        /*
         *https://www.interviewbit.com/problems/spiral-order-matrix-i/
         *
         *Given a matrix of m * n elements (m rows, n columns), return all elements of the matrix in spiral order.

           Example:

           Given the following matrix:

           [
               [ 0, 1, 2 ],
               [ 3, 4, 5 ],
               [ 6, 7, 8 ]
           ]

           You should return

           [0, 1, 2, 5, 5, 7, 6, 3, 4]
         */

        public List<int> PrintInSpiralOrder(int[,] m)
        {
            List<int> results = new List<int>();
            int leftCol = 0;
            int topRow = 0;
            int rightCol = m.GetLength(1) - 1;
            int botRow = m.GetLength(0) - 1;
            int dir = 0;

            while (topRow <= botRow && leftCol <= rightCol)
            {
                if (dir == 0)
                {
                    for (int i = leftCol; i <= rightCol; i++)
                        results.Add(m[topRow, i]);
                    topRow++;
                }
                else if (dir == 1)
                {
                    for (int i = topRow; i <= botRow; i++)
                        results.Add(m[i, rightCol]);
                    rightCol--;
                }
                else if (dir == 2)
                {
                    for (int i = rightCol; i >= leftCol; i--)
                        results.Add(m[botRow, i]);
                    botRow--;
                }
                else if (dir == 3)
                {
                    for (int i = botRow; i >= topRow; i--)
                        results.Add(m[i, leftCol]);
                    leftCol++;
                }

                dir = (dir + 1) % 4;
            }

            return results;
        }
    }
}