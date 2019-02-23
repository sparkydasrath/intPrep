using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class LetterPhoneNumbers
    {
        private readonly string[] map;

        public LetterPhoneNumbers() => map = new string[]
            {
               "",
               "",
               "abc",
               "def",
               "ghi",
               "jkl",
               "mno",
               "pqrs",
               "tuv",
               "wxyz",
            };

        public List<string> LetterCombinations(string digits)
        {
            /*
             *Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

               A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

               Example:

               Input: "23"
               Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

             *
             */

            List<string> results = new List<string>();

            if (string.IsNullOrEmpty(digits)) return results;

            StringBuilder accumulator = new StringBuilder();
            LetterCombinationsHelper(digits, accumulator, results);
            return results;
        }

        private void LetterCombinationsHelper(string digits, StringBuilder accumulator, List<string> results)
        {
            // base case need to know when to stop the recursion - know this by the length ex: if
            // digits = 2, then as soon as we accumulate two letters into the string builder we can stop

            if (accumulator.Length == digits.Length)
                results.Add(accumulator.ToString());
            else
            {
                int accLength = accumulator.Length;
                int index = digits[accLength] - '0';
                string letters = map[index];

                for (int i = 0; i < letters.Length; i++)
                {
                    // choose
                    accumulator.Append(letters[i]);

                    //explore
                    LetterCombinationsHelper(digits, accumulator, results);

                    //un-choose
                    accumulator.Remove(accumulator.Length - 1, 1);
                }
            }
        }
    }
}