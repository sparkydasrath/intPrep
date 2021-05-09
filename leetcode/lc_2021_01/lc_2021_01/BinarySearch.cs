using System.Collections.Generic;

namespace lc_2021_01
{
    /// <summary>
    /// Basic binary search that return index if found, -1 if not
    /// </summary>
    public class BinarySearch
    {
        public int IsPresent(List<int> list, int target, bool isSorted = true)
        {
            if (list.Count == 0) return -1;
            if (!isSorted) list.Sort();
            return Search(list, target, 0, list.Count - 1);
        }

        private int Search(List<int> list, int target, int left, int right)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] == target) return mid; // return index
                if (list[mid] < target) left = mid + 1;
                else if (list[mid] > target) right = mid - 1;
            }

            return -1;
        }
    }
}