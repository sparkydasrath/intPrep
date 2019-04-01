using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTests
{
    public class Annaly
    {
        public static int EfficientJanitor(List<float> weight)
        {
            if (weight == null || weight.Count == 0) return 0;

            int trips = 0;
            for (int i = 0; i < weight.Count; i++)
            {
                if (weight[i] == float.MinValue) continue;
                for (int j = i + 1; j < weight.Count; j++)
                {
                    // find the first pair where the sum < 3.00
                    if (weight[i] == float.MinValue || weight[j] == float.MinValue) continue;

                    float sum = weight[i] + weight[j];
                    if (sum <= 3.00f)
                    {
                        trips += 1;
                        weight[i] = float.MinValue;
                        weight[j] = float.MinValue;
                    }
                }
            }

            // check if there are any left over weights left
            IEnumerable<float> leftovers = weight.Where(w => w != float.MinValue);
            trips += leftovers.Count();
            return trips;
        }

        public static int EfficientJanitorHelper(float[] weight) => EfficientJanitor(weight.ToList());

        public static int MaxDifference(List<int> nums)
        {
            if (nums == null || nums.Count == 0) return 0;

            int max = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                List<int> temp = nums.GetRange(0, i);
                int currentNum = nums[i];
                int tempMax = 0;
                for (int j = 0; j < temp.Count; j++)
                    temp[j] = currentNum - temp[j];

                Console.WriteLine($"temp pass on current {currentNum}");
                foreach (int x in temp)
                {
                    Console.WriteLine(string.Join(" ", x));
                }

                tempMax = temp.Max();

                max = Math.Max(max, tempMax);
            }

            return max;
        }

        public static int MaxDifferenceInner(int[] nums) => MaxDifference(nums.ToList());

        public static string Winner(List<int> andrea, List<int> maria, string s) => WinnerHelper(andrea.ToArray(), maria.ToArray(), s);

        public static string WinnerHelper(int[] a, int[] m, string s)
        {
            List<int> andrea = a.ToList();
            List<int> maria = m.ToList();

            if (andrea == null && maria == null) return "Tie";
            if (andrea == null && maria != null) return "Maria";
            if (andrea != null && maria == null) return "Andrea";

            List<int> andreaResults = new List<int>();
            List<int> mariaResults = new List<int>();

            int cardCount = andrea.Count;

            if (s == "Odd")
            {
                andrea.RemoveAt(0);
                maria.RemoveAt(0);
            }

            for (int i = 0; i < cardCount; i++)
            {
                if (i % 2 == 0 || i % 2 == 0)
                {
                    andreaResults.Add(andrea[i] - maria[i]);
                    mariaResults.Add(maria[i] - andrea[i]);
                }
            }

            int andreaScore = andreaResults.Sum();
            int mariaScore = mariaResults.Sum();

            if (andreaScore > mariaScore) return "Andrea";
            if (mariaScore > andreaScore) return "Marie";
            return "Tie";
        }
    }
}