namespace Strings
{
    public class IntegerToEnglishWords
    {
        /*
         273. Integer to English Words
        Hard

        Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.

        Example 1:

        Input: 123
        Output: "One Hundred Twenty Three"

        Example 2:

        Input: 12345
        Output: "Twelve Thousand Three Hundred Forty Five"

        Example 3:

        Input: 1234567
        Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"

        Example 4:

        Input: 1234567891
        Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"

         */

        private readonly string[] belowHundred = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private readonly string[] belowTen = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] belowTwenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        public string NumberToWords(int num)
        {
            // https://leetcode.com/problems/integer-to-english-words/discuss/70627/Short-clean-Java-solution
            if (num == 0) return "Zero";
            return Helper(num);
        }

        private string Helper(int num)
        {
            string result;
            if (num < 10) result = belowTen[num];
            else if (num < 20) result = belowTwenty[num - 10];
            else if (num < 100) result = belowHundred[num / 10] + " " + Helper(num % 10);
            else if (num < 1000) result = Helper(num / 100) + " Hundred " + Helper(num % 100);
            else if (num < 1000000) result = Helper(num / 1000) + " Thousand " + Helper(num % 1000);
            else if (num < 1000000000) result = Helper(num / 1000000) + " Million " + Helper(num % 1000000);
            else result = Helper(num / 1000000000) + " Billion " + Helper(num % 1000000000);
            return result.Trim();
        }
    }
}