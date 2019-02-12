using System;

namespace InterviewBit
{
    internal class Program
    {
        public static int FindRotationCount(int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                if (array[low] <= array[high]) return low;
                int mid = (low + high) / 2;
                int next = (mid + 1) % array.Length;
                int prev = (mid + array.Length - 1) % array.Length;

                if (array[mid] <= array[next] && array[mid] <= array[prev]) return mid;
                if (array[mid] <= array[high]) high = mid - 1;
                else if (array[mid] >= array[low]) low = mid + 1;
            }

            return -1;
        }

        public int SearchNumOccurrence(int[] array, int k, int start, int end)
        {
            if (start > end) return 0;
            int mid = (start + end) / 2;
            if (array[mid] < k) return SearchNumOccurrence(array, k, mid + 1, end);
            if (array[mid] > k) return SearchNumOccurrence(array, k, start, mid - 1);
            return SearchNumOccurrence(array, k, start, mid - 1) + 1 + SearchNumOccurrence(array, k, mid + 1, end);
        }

        private static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3 };
            int res = FindRotationCount(array);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}