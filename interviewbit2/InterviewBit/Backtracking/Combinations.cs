using System;
using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class Combinations
    {
        /*
         * Following Tushar's guide: https://www.youtube.com/watch?v=xTNFs5KRV_g

           String Combination/ subset with repeating characters

            Algorithm:
            1. For input string, create a count array
                ex: aabc

                char   count
            --------------------
                a       2
                b       1
                c       1
            2. Create result array which is the input string's length
            3. Go from left to right and look for the first available char
                3a. A char is available if it's count > 0
            4. Put that char in the corresponding position in the result array
                NOTE: The position/index into the array is determined by the depth of the recursion
            5. Decrement the count (since we used it for the current step) and recurse
            6. Print what is in the result BUT you only print up to the depth
                ex: if depth is 1, then you will only print results[0] and results[1]
            7. When you recurse, you need to pass along the position of the array you worked on to the
                next step and increase the depth
            6. When you return from the recursion
                6a. Restore the count
                6b. You need to explore from where you left off in step 7
                So start looking from that position on wards and then look for the next available
                character that has count > 0
         */

        private readonly Dictionary<char, int> map;
        private Tuple<char[], int[]> charCountPair;
        private char[] result;

        public Combinations()
        {
            map = new Dictionary<char, int>();
            AllResults = new List<string>();
        }

        public List<string> AllResults { get; }

        public void CombineWithRepeatedCharsBase(string input)
        {
            // assume that s is already sorted so we are getting aabc

            // create count array
            foreach (char c in input)
            {
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else map[c] += 1;
            }

            // create two arrays representing the above mapping of char to count
            charCountPair = GetCharAndCountArrayFromMap(map);

            // create result array
            result = new char[input.Length];

            CombineWithRepeatedCharsDfs(charCountPair.Item1, charCountPair.Item2, result, 0, 0);
        }

        public List<List<int>> SubsetsDfs(int[] nums)
        {
            List<List<int>> results = new List<List<int>>();

            if (nums.Length == 0) return results;

            List<int> accumulator = new List<int>();
            SubsetsDfsHelper(nums, 0, accumulator, results);

            return results;
        }

        public void SubsetsDfsHelper(int[] input, int position, List<int> accumulator, List<List<int>> results)
        {
            /*
                this guy has a good drawing (explanation is shit)
                https://www.youtube.com/watch?v=rxitBSy8pZ0
            */

            if (position == input.Length)
            {
                List<int> res = new List<int>(accumulator);
                results.Add(res);

                StringBuilder sb = new StringBuilder();
                foreach (int r in res)
                {
                    sb.Append(r);
                }

                AllResults.Add(sb.ToString());
            }
            else
            {
                // explore without item
                SubsetsDfsHelper(input, position + 1, accumulator, results);

                // explore with item
                accumulator.Add(input[position]);
                SubsetsDfsHelper(input, position + 1, accumulator, results);

                // unchoose item
                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="input">
        /// The array of the reduced string based on the count of the repeating chars
        /// </param>
        /// <param name="counts">Array mapping the count of the chars to the input array</param>
        /// <param name="output">
        /// Sized to be the length of the original passed in string we reduced to get input array
        /// </param>
        /// <param name="positionInString">
        /// The index we are looking at to tell the next recursion where to start exploring from
        /// </param>
        /// <param name="depth">Depth of the recursion tree</param>
        private void CombineWithRepeatedCharsDfs(char[] input, int[] counts, char[] output, int positionInString, int depth)
        {
            // at each recursive step, as soon as you add/remove an item to the output array just
            // print it/add to results
            PrintArray(output, depth);

            for (int i = positionInString; i < input.Length; i++)
            {
                if (counts[i] == 0) continue;

                // add char to output
                output[depth] = input[i];

                // decrement count
                counts[i]--;

                // recurse and increase depth and pass along the position you are coming from
                CombineWithRepeatedCharsDfs(input, counts, output, i, depth + 1);

                // restore count
                counts[i]++;
            }
        }

        private Tuple<char[], int[]> GetCharAndCountArrayFromMap(Dictionary<char, int> map)
        {
            // create two arrays representing the above mapping of char to count
            char[] str = new char[map.Count];
            int[] counts = new int[map.Count];
            int index = 0;
            foreach (KeyValuePair<char, int> kvp in map)
            {
                str[index] = kvp.Key;
                counts[index] = kvp.Value;
                index++;
            }

            return new Tuple<char[], int[]>(str, counts);
        }

        private void PrintArray(char[] res, int lengthOfArrayToPrint)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lengthOfArrayToPrint; i++)
                sb.Append(res[i]);

            AllResults.Add(sb.ToString());
            Console.WriteLine(sb.ToString());
        }
    }
}