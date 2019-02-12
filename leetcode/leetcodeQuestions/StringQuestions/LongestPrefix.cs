namespace StringQuestions
{
    public class LongestPrefix
    {
        /*
         * Write a function to find the longest common prefix string amongst an array of strings.

           If there is no common prefix, return an empty string "".

           Example 1:

           Input: ["flower","flow","flight"]
           Output: "fl"

           Example 2:

           Input: ["dog","racecar","car"]
           Output: ""
           Explanation: There is no common prefix among the input strings.

           Note:

           All given inputs are in lowercase letters a-z.

         */

        public string LongestCommonPrefix(string[] strs)
        {
            string pfx = "";
            int minLen = int.MaxValue;
            int minIndex = 0;
            string pivot = "";
            int matchedCount = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLen)
                {
                    minLen = strs[i].Length;
                    minIndex = i;
                }
            }

            if (minLen == 0 || minIndex == int.MinValue) return pfx;  // handle case of an empty string in the list

            pivot = strs[minIndex];
            int[] matchedIndices = new int[pivot.Length];

            for (int i = 0; i < minLen; i++)
            {
                char comparer = pivot[i];
                for (int j = 0; j < strs.Length; j++)
                {
                    if (comparer == (strs[j])[i])
                    {
                        matchedCount++;
                    }
                }

                if (matchedCount == strs.Length)
                {
                    matchedIndices[i] = 1;
                    pfx += comparer;
                }

                matchedCount = 0;
            }

            return matchedIndices[0] == 0 ? "" : pfx;
        }
    }
}