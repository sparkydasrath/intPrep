using System.Collections.Generic;

namespace Strings
{
    public class LongestCommonPrefix
    {
        public string GetLongestCommonPrefix(List<string> A)
        {
            if (A.Count == 0) return "";

            string lcpfx = A[0];

            for (int i = 1; i < A.Count; i++)
            {
                int j = 0;
                string cur = A[i];
                while (j < lcpfx.Length && j < cur.Length && lcpfx[j] == cur[j])
                {
                    j++;
                }
                if (j == 0) return "";
                lcpfx = lcpfx.Substring(0, j);
            }

            return lcpfx;
        }
    }
}