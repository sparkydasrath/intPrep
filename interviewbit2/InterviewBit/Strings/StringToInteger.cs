using System;
using System.Collections.Generic;

namespace Strings
{
    /*
     *https://leetcode.com/problems/string-to-integer-atoi/
     *
     * Implement atoi which converts a string to an integer.

       The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

       The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

       If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

       If no valid conversion could be performed, a zero value is returned.

       Note:

       Only the space character ' ' is considered as whitespace character.
       Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.

       Example 1:

       Input: "42"
       Output: 42

       Example 2:

       Input: "   -42"
       Output: -42
       Explanation: The first non-whitespace character is '-', which is the minus sign.
       Then take as many numerical digits as possible, which gets 42.

       Example 3:

       Input: "4193 with words"
       Output: 4193
       Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.

       Example 4:

       Input: "words and 987"
       Output: 0
       Explanation: The first non-whitespace character is 'w', which is not a numerical
       digit or a +/- sign. Therefore no valid conversion could be performed.

       Example 5:

       Input: "-91283472332"
       Output: -2147483648
       Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
       Thefore INT_MIN (−231) is returned.

     */

    public class StringToInteger
    {
        private bool isNegative;
        private Stack<int> stack = new Stack<int>();

        public int ConvertStringToInteger(string str)
        {
            string s = str.Trim();

            if (string.IsNullOrWhiteSpace(s)) return 0;
            if (IsFirstCharacterALetter(s[0])) return 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (IsNegative(s[i]))
                {
                    isNegative = true; // check if the number is negative
                    continue;
                }

                if (IsExplicitPositive(s[i])) continue; // handle case +1

                int temp = s[i] - '0';

                if (IsWhitespace(s[i])) break; // string starts with number and has letters later on
                if (IsDecimal(s[i])) break; // if it has a decimal, truncate and take the left side
                stack.Push(temp);
            }

            int sum = GetSum();

            return isNegative == false ? sum : -1 * sum;
        }

        private int GetSum()
        {
            int sum = 0;
            int j = 0;
            while (stack.Count > 0)
            {
                int partialResult = stack.Pop() * (int)Math.Pow(10, j);
                if (partialResult == int.MinValue) return int.MinValue;
                sum += partialResult;
                j++;
            }

            return sum;
        }

        private bool IsDecimal(char c) => c == '.';

        private bool IsExplicitPositive(char c) => c == '+';

        private bool IsFirstCharacterALetter(char c)
        {
            int temp = c - '0';
            if (temp >= 0 && temp <= 9 || IsNegative(c) || IsExplicitPositive(c)) return false;
            return true;
        }

        private bool IsNegative(char c) => c == '-';

        private bool IsWhitespace(char c) => c == ' ';
    }
}