using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Strings
{
    public class ZigZagConversion
    {
        /*https://leetcode.com/problems/zigzag-conversion/
         *
         * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

           P   A   H   N
           A P L S I I G
           Y   I   R

           And then read line by line: "PAHNAPLSIIGYIR"

           Write the code that will take a string and make this conversion given a number of rows:

           string convert(string s, int numRows);

           Example 1:

           Input: s = "PAYPALISHIRING", numRows = 3
           Output: "PAHNAPLSIIGYIR"

           Example 2:

           Input: s = "PAYPALISHIRING", numRows = 4
           Output: "PINALSIGYAHRPI"
           Explanation:

           P     I    N
           A   L S  I G
           Y A   H R
           P     I

         */

        public string ConvertLc(string s, int numRows)
        {
            // this approach figures out how many rows we need and create a string builder for each

            if (numRows == 1) return s;
            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                rows.Add(new StringBuilder());
            }

            int currentRow = 0;
            bool directionDown = false;

            foreach (char c in s)
            {
                rows[currentRow].Append(c);
                if (currentRow == 0 || currentRow == numRows - 1)
                {
                    directionDown = !directionDown;
                }

                currentRow += directionDown ? 1 : -1;
            }

            StringBuilder sb = new StringBuilder();
            foreach (StringBuilder rsb in rows)
            {
                sb.Append(rsb);
            }

            return sb.ToString();
        }

        public string ConvertMine(string s, int numRows)
        {
            // my solution is overly complicated and breaks test case for numRows=2

            if (numRows <= 1) return s;

            int numCols = s.Length / 2;
            string[,] m = MatrixUtils.BuildMatrixGeneric<string>(numRows, numCols + 1);
            int dir = 0;
            int rowNum = -1;
            int colNum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (dir == 0)
                {
                    rowNum++;
                    m[rowNum, colNum] = s[i].ToString();

                    if (rowNum == numRows - 1)
                    {
                        dir = 1;
                        colNum++;
                        continue;
                    }
                }

                if (dir == 1)
                {
                    rowNum--;
                    m[rowNum, colNum] = s[i].ToString();
                    colNum++;

                    if (rowNum <= 1)
                    {
                        dir = 0;
                        // colNum++;
                        rowNum = -1;
                        continue;
                    }
                }
            }

            MatrixUtils.PrintMatrixGeneric(m);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    string item = m[i, j];
                    if (!string.IsNullOrWhiteSpace(item))
                        sb.Append(item);
                }
            }

            return sb.ToString();
        }
    }
}