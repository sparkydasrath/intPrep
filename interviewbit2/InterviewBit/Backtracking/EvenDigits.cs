using System;
using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class EvenDigits
    {
        /*
    Write a recursive method named EvenDigits that accepts an integer parameter n and
    returns a new integer containing only the even digits from n, in the same order. If n does not contain any even digits, return 0.
    For example, the call of EvenDigits(8342116) should return 8426 and the call of EvenDigits(35179)
    should return 0.

             */

        public int CountNumberOfEvenDigits(int n)
        {
            // base case
            if (n / 10 == 0)
                return n % 2 == 0 ? 1 : 0;
            return (n % 10 % 2 == 0 ? 1 : 0) + CountNumberOfEvenDigits(n / 10);
        }

        public int EvenDigitsDfs(int n)
        {
            List<string> results = new List<string>();
            string input = n.ToString();

            EvenDigitsDfsHelper(input, results, 0);

            if (results.Count == 0) return 0;
            StringBuilder sb = new StringBuilder();
            results.ForEach(r => sb.Append(r));
            return Convert.ToInt32(sb.ToString());
        }

        private void EvenDigitsDfsHelper(string input, List<string> results, int position)
        {
            if (position == input.Length) return;

            if (input[position] % 2 == 0)
            {
                results.Add(input[position].ToString());
                EvenDigitsDfsHelper(input, results, position + 1);
            }
            else EvenDigitsDfsHelper(input, results, position + 1);
        }
    }
}