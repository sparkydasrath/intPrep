using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgQuestions
{
    // https://www.youtube.com/watch?v=aYnEO53H4lw&list=PLamzFoFxwoNjtJZoNNAlYQ_Ixmm2s-CGX&index=17
    public class MaxSizeSquareSubMatrix
    {
        public int LargestSquareMatrix(int[,] m)
        {
            if (m == null) return 0;
            int largest = 0;
            int r = m.GetLength(0);
            int c = m.GetLength(1);
            int[,] output = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        output[i, j] = m[i, j];
                    }
                    else if (m[i, j] == 0)
                    {
                        output[i, j] = 0;
                    }
                    else
                    {
                        List<int> mins = new List<int>()
                        {
                            output[i, j - 1],        //left
                            output[i - 1, j - 1],    // nw
                            output[i - 1, j]         //up
                        };
                        int currentMin = mins.Min(x => x) + 1;
                        output[i, j] = currentMin;
                        largest = Math.Max(largest, currentMin);
                    }
                }
            }
            return largest;
        }
    }
}