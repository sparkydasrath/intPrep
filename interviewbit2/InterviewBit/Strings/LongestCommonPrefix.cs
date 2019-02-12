using System.Collections.Generic;

namespace Strings
{
    public class LongestCommonPrefix
    {
        public string GetLongestCommonPrefix(List<string> strs)
        {
            if (strs.Count == 0) return "";

            string lcpfx = strs[0];

            for (int i = 1; i < strs.Count; i++)
            {
                int j = 0;
                string cur = strs[i];
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