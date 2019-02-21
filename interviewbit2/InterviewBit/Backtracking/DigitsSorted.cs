namespace Backtracking
{
    public class DigitsSorted
    {
        /*
         https://www.codestepbystep.com/problem/view/csharp/recursion/DigitsSorted

        Write a recursive method named DigitsSorted that takes an integer as a parameter and returns true if the digits of the integer are sorted and false otherwise. The digits must be sorted in non-decreasing order (i.e. increasing order with duplicate digits allowed) when read from left to right. An integer that consists of a single digit is sorted by definition. The method should be also able to handle negative numbers. Negative numbers are also considered sorted if their digits are in non-decreasing order.

        The following table shows several calls to your method and their expected return values:

        Call 	                Value Returned
        DigitsSorted(0) 	    true
        DigitsSorted(2345) 	    true
        DigitsSorted(-2345) 	true
        DigitsSorted(22334455) 	true
        DigitsSorted(-5) 	    true
        DigitsSorted(4321) 	    false
        DigitsSorted(24378) 	false
        DigitsSorted(21) 	    false
        DigitsSorted(-33331) 	false

        Constraints: Do not declare any global variables. Do not use any loops; you must use recursion. Do not use any auxiliary data structures like List, SortedDictionary, SortedSet, array, etc. Also do not solve this problem using a string. You can declare as many primitive variables like ints as you like. You are allowed to define other "helper" methods if you like; they are subject to these same constraints.

                 */

        public bool DigitsSortedDfs(int n)
        {
            string input = n.ToString();

            if (input.Length == 1) return true;
            if (input.Length == 2 && input.StartsWith("-")) return true;

            // don't care if it is negative, just strip it out and use the raw number this will avoid
            // annoying checks in the helper

            if (input.StartsWith("-"))
            {
                input = input.Remove(0, 1);
            }

            // if (DigitsSortedDfsHelper(input, string.Empty, 0)) return true;

            if (DigitsSortedDfsHelper(input, input.Length)) return true;

            return false;
        }

        private bool DigitsSortedDfsHelper(string input, int length)
        {
            //treat string as array of numbers (represented as chars)
            if (length == 0 || length == 1) return true;
            if (input[length - 1] < input[length - 2]) return false;
            return DigitsSortedDfsHelper(input, length - 1);
        }
    }
}