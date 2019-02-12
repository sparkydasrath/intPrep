using System;
using System.Collections.Generic;

namespace Arrays
{
    public class SpiralMatrix
    {
        /*
         * https://www.interviewbit.com/problems/spiral-order-matrix-i/
         *
         *  [
                [ 1, 2, 3 ],
                [ 4, 5, 6 ],
                [ 7, 8, 9 ]
            ]

        You should return

        [1, 2, 3, 6, 9, 8, 7, 4, 5]
         */

        public void Print(int a) => Console.WriteLine($"\t {a} \t");

        public string PrintSpiralMatrix(int[,] m)
        {
            // StringBuilder sb = new StringBuilder();
            string s = string.Empty;
            int topRow = 0;
            int botRow = m.GetLength(0) - 1;
            int leftCol = 0;
            int rightCol = m.GetLength(1) - 1;
            int dir = 0;
            List<int> r = new List<int>();

            while (topRow <= botRow && leftCol <= rightCol)
            {
                if (dir == 0)
                {
                    for (int i = leftCol; i <= rightCol; i++)
                    {
                        int res = m[topRow, i];
                        Print(res);
                        //sb.Append(string.Format("{0} {1} {2}", " ", res, " "));
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    topRow++;
                }
                else if (dir == 1)
                {
                    for (int i = topRow; i <= botRow; i++)
                    {
                        int res = m[i, rightCol];
                        Print(res);
                        //sb.Append($" {res} ");
                        //sb.Append(string.Format("{0} {1} {2}", " ", res, " "));
                        r.Add(res);
                        s += " " + res + " ";
                    }

                    rightCol--;
                }
                else if (dir == 2)
                {
                    for (int i = rightCol; i >= leftCol; i--)
                    {
                        int res = m[botRow, i];
                        Print(res);
                        //                        sb.Append($" {res} ");
                        //sb.Append(string.Format("{0} {1} {2}", " ", res, " "));
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    botRow--;
                }
                else if (dir == 3)
                {
                    for (int i = botRow; i >= topRow; i--)
                    {
                        int res = m[i, leftCol];
                        Print(res);
                        //                        sb.Append($" {res} ");
                        //sb.Append(string.Format("{0} {1} {2}", " ", res, " "));
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    leftCol++;
                }

                dir = (dir + 1) % 4;
            }

            string trimmed = s.Trim();

            return trimmed;
        }

        public List<int> SpiralOrder(List<List<int>> m)
        {
            string s = string.Empty;
            int topRow = 0;
            int botRow = m.Count - 1;
            int leftCol = 0;
            int rightCol = m[0].Count - 1;
            int dir = 0;
            List<int> r = new List<int>();

            while (topRow <= botRow && leftCol <= rightCol)
            {
                if (dir == 0)
                {
                    for (int i = leftCol; i <= rightCol; i++)
                    {
                        int res = m[topRow][i];
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    topRow++;
                }
                else if (dir == 1)
                {
                    for (int i = topRow; i <= botRow; i++)
                    {
                        int res = m[i][rightCol];
                        r.Add(res);
                        s += " " + res + " ";
                    }

                    rightCol--;
                }
                else if (dir == 2)
                {
                    for (int i = rightCol; i >= leftCol; i--)
                    {
                        int res = m[botRow][i];
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    botRow--;
                }
                else if (dir == 3)
                {
                    for (int i = botRow; i >= topRow; i--)
                    {
                        int res = m[i][leftCol];
                        s += " " + res + " ";
                        r.Add(res);
                    }

                    leftCol++;
                }

                dir = (dir + 1) % 4;
            }

            string t = s.Trim();

            return r;
        }
    }
}