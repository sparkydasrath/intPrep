using System.Collections.Generic;

namespace Strings
{
    public class ValidParentheses
    {
        /*
         * 20. Valid Parentheses https://leetcode.com/problems/valid-parentheses/
            Easy

            Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

            An input string is valid if:

                Open brackets must be closed by the same type of brackets.
                Open brackets must be closed in the correct order.

            Note that an empty string is also considered valid.

            Example 1:

            Input: "()"
            Output: true

            Example 2:

            Input: "()[]{}"
            Output: true

            Example 3:

            Input: "(]"
            Output: false

            Example 4:

            Input: "([)]"
            Output: false

            Example 5:

            Input: "{[]}"
            Output: true

         */

        public bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Pop();
                    if (top != '(') return false;
                }
                else if (c == ']')
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Pop();
                    if (top != '[') return false;
                }
                else if (c == '}')
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Pop();
                    if (top != '{') return false;
                }
            }

            if (stack.Count == 0) return true;
            return false;
        }
    }
}