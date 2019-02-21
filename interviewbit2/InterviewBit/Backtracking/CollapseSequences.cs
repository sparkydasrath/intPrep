using System.Text;

namespace Backtracking
{
    public class CollapseSequences
    {
        /*
         * https://www.codestepbystep.com/problem/view/csharp/recursion/CollapseSequences
         *
         *

        Write a recursive method named CollapseSequences that accepts a string s and char c as parameters and returns a new string that is the same as s but with any sequences of consecutive occurrences of c compressed into a single occurrence of c. For example, if we collapse sequences of character 'a' in the string "aabaaccaaaaada", you get "abaccada".

        Your method is case-sensitive; if the character c is, for example, a lowercase 'f', your method should not collapse sequences of uppercase 'F' characters. In other words, you do not need to write code to handle case issues in this problem.

        The following table shows several calls and their expected return values:
        Call 	Returns
        CollapseSequences("aabaaccaaaaaada", 'a') 	"abaccada"
        CollapseSequences("mississssipppi", 's') 	"misisipppi"
        CollapseSequences("babbbbebbbxbbbbbb", 'b') 	"babebxb"
        CollapseSequences("palo alto", 'o'); 	"palo alto"
        CollapseSequences("tennessee", 'x') 	"tennessee"
        CollapseSequences("", 'x') 	""

        Constraints: Do not declare any global variables. Do not use any loops; you must use recursion. Do not call any of the following string member methods: find, rfind, indexOf, contains, replace, split. (The point of this problem is to solve it recursively; do not use a library method to get around recursion.) Do not use any auxiliary data structures like List, SortedDictionary, SortedSet, array, etc. You can declare as many primitive variables like ints as you like, as well as strings. You are allowed to define other "helper" methods if you like; they are subject to these same constraints.

         */
        private readonly StringBuilder sb = new StringBuilder();

        public string CollapseSequencesDfs(string s, char c)
        {
            if (s.Length <= 1) return s;

            sb.Clear();

            CollapseSequencesDfsHelper(s, c, string.Empty, 0);
            return sb.ToString();
        }

        public void CollapseSequencesDfsHelper(string s, char c, string output, int position)
        {
            if (position == s.Length)
            {
                sb.Append(output);
                return; // have exhausted searching the string
            }

            if (output.Length == 0)
            {
                // append the first char
                output += s[position];
                // recurse
                CollapseSequencesDfsHelper(s, c, output, position + 1);
            }
            else
            {
                // if the last char of the output is the same as the char we want to replace, ignore
                // and recurse
                if (s[position] == c && output[output.Length - 1] == c)
                    CollapseSequencesDfsHelper(s, c, output, position + 1);
                else
                {
                    // otherwise, append the current char and recurse
                    output += s[position];
                    CollapseSequencesDfsHelper(s, c, output, position + 1);
                }
            }
        }
    }
}