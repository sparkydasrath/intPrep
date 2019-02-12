namespace StringQuestions
{
    public class StringManipulation
    {
        public int GetIndextOfSubstring(string str, string substr)
        {
            int result = -1;

            if (substr.Length > str.Length) return result;
            if (substr == str) return 0;
            if (substr == "") return 0;

            for (int i = 0; i <= str.Length - substr.Length; i++)
            {
                int cnt = 0;
                for (int j = 0; j < substr.Length; j++)
                {
                    if (str[i + j] == substr[j])
                    {
                        cnt++;
                    }
                    else
                    {
                        result = -1;
                        break;
                    }
                }

                if (cnt == substr.Length)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public int StrStr(string haystack, string needle)
        {
            /*
             * Implement strStr().

               Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

               Example 1:

               Input: haystack = "hello", needle = "ll"
               Output: 2

               Example 2:

               Input: haystack = "aaaaa", needle = "bba"
               Output: -1

               Clarification:

               What should we return when needle is an empty string? This is a great question to ask during an interview.

               For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

             */

            int winLen = needle.Length;
            int iterLen = haystack.Length - winLen;
            int matchCount = 0;
            int startIndex = -1;

            if (string.IsNullOrWhiteSpace(needle)) return 0;
            if (haystack == needle) return 0;

            if (needle.Length > haystack.Length) return -1;

            int i = 0;
            while (i <= iterLen)
            {
                if (haystack[i] != needle[0])
                {
                    i++;
                    continue;
                }

                // if the first letter matches, check remaining in window
                else
                {
                    for (int j = 0; j < winLen; j++)
                    {
                        if (haystack[i + j] == needle[j])
                        {
                            matchCount++;
                        }
                        else
                        {
                            matchCount = 0;
                            break;
                        }
                    }

                    if (winLen == matchCount)
                    {
                        startIndex = i;
                        break;
                    }
                }

                i++;
            }
            return startIndex;
        }
    }
}