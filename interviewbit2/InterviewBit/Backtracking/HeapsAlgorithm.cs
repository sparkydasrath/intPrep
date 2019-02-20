using System;
using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class HeapsAlgorithm
    {
        /*
         * https://en.wikipedia.org/wiki/Heap%27s_algorithm
         * Heap's algorithm generates all possible permutations of n UNIQUE objects best
         * It does generate ALL permutations and in the case of repeated numbers/chars (in case of string)
         *  it will treat the repeated number as as it was never seen
         * ex:
         *  aabc using heap will generate 24 permutations (4!)
         *  aabc using Tushar's approach will generate 12, discarding repeats (4!/2!) [the 2! is for the repeated aa]
         *  (https://www.youtube.com/watch?v=nYFd7VHKyWQ&feature=youtu.be)
         */

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="size">Number of items to generate. Usually use array.Length as this param</param>
        /// <param name="n">
        /// The length of the output. If the array has 4 items and you set this to 2, it will
        /// generate permutations of length 2 with a ton of repeats Best to use array.Length for this
        /// </param>
        public void PermuteUsingHeapsAlgorithm(int[] array, int size, int n)
        {
            if (size == 1)
            {
                Print(array, n);
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    PermuteUsingHeapsAlgorithm(array, size - 1, n);

                    // if size is odd, swap first and last element
                    if (size % 2 == 1)
                    {
                        // can clean this up by writing a swap() method
                        int temp = array[0];
                        array[0] = array[size - 1];
                        array[size - 1] = temp;
                    }

                    // If size is even, swap ith and last element
                    else
                    {
                        int temp = array[i];
                        array[i] = array[size - 1];
                        array[size - 1] = temp;
                    }
                }
            }
        }

        public void Print(int[] arr, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(arr[i] + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        public void PrintUnique(int[] arr, int length)
        {
            StringBuilder sb = new StringBuilder();
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < length; i++)
            {
                sb.Append(arr[i] + " ");
            }

            if (!set.Contains(sb.ToString())) set.Add(sb.ToString());

            foreach (string item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}