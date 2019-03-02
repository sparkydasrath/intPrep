using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class GenerateParentheses
    {
        /*
         https://www.geeksforgeeks.org/applications-of-catalan-numbers/
         * https://leetcode.com/problems/generate-parentheses/
         * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

           This is NOT a Catalan number problem as explained: https://www.youtube.com/watch?v=m9Khxn2g-6w

           For example, given n = 3, a solution set is:

           [
               "((()))",
               "(()())",
               "(())()",
               "()(())",
               "()()()"
           ]
         */

        public List<string> GenerateParenthesis(int n)
        {
            /*
             * I was still unable to reason about how to even set this up and it is very frustrating that I am making
             * so little progress on these backtracking/recursion problems
             *
             * I am having a hard time visualizing what the solution entails
             *
             */

            if (n == 0) return new List<string>();

            List<string> results = new List<string>();
            StringBuilder accumulator = new StringBuilder();
            GenerateParenthesisHelper(0, 0, accumulator, results, n);

            return results;
        }

        private void GenerateParenthesisHelper(int open, int close, StringBuilder accumulator, List<string> results, int n)
        {
            if (open == n && close == n)
            {
                results.Add(accumulator.ToString());
                return;
            }

            if (open < n)
            {
                GenerateParenthesisHelper(open + 1, close, accumulator.Append("("), results, n);
                accumulator.Remove(accumulator.Length - 1, 1);
            }

            if (close < open)
            {
                GenerateParenthesisHelper(open, close + 1, accumulator.Append(")"), results, n);
                accumulator.Remove(accumulator.Length - 1, 1);
            }
        }
    }
}