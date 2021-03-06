﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewTests.Blackstone
{
    public struct NumbersAndK
    {
        // prefer this over using Item1, Item2 in Tuple
        public int K { get; set; }

        public string Numbers { get; set; }
    }

    public class ReverseKthNumbers
    {
        // this is the question 2

        /*
            Programming Challenge Description:
            Given a list of numbers and a positive integer k, reverse the elements of the list, k items at a time.
            If the number of elements is not a multiple of k, then the remaining items in the end should be left as is.
            Input:
            Your program should read lines from standard input. Each line contains a list of numbers and the number k,
            separated by a semicolon. The list of numbers are comma delimited.
            Output:
            Print out the new comma separated list of numbers obtained after reversing.
         */

        public string ReverseKth(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            NumbersAndK numbersAndK = ParseInput(input);
            StringBuilder sb = new StringBuilder(); // accumulate results
            int div = numbersAndK.Numbers.Length / numbersAndK.K;
            int mod = numbersAndK.Numbers.Length % numbersAndK.K;
            // move out here to make loop look cleaner - want to only iterate to the end of valid chunks
            int iterLength = numbersAndK.Numbers.Length - mod;

            for (int i = 0; i < iterLength; i += numbersAndK.K)
            {
                string subStr = numbersAndK.Numbers.Substring(i, numbersAndK.K);
                IEnumerable<char> subStrReversed = subStr.Reverse();
                foreach (char c in subStrReversed) sb.Append(c);
            }

            if (mod != 0)
            {
                // deal with left over
                string remaining = numbersAndK.Numbers.Substring(iterLength);
                foreach (char c in remaining) sb.Append(c);
            }

            string result = string.Join(",", sb.ToString().ToCharArray());

            return result;
        }

        private NumbersAndK ParseInput(string numsAndk)
        {
            NumbersAndK nAndk = new NumbersAndK();

            string[] split = numsAndk.Split(';');
            string numsAsString = split[0].Replace(",", string.Empty);
            string k = split[1];
            return new NumbersAndK { Numbers = numsAsString, K = Convert.ToInt32(k) };
        }
    }
}