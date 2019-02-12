namespace SearchAndSort
{
    public class Searches
    {
        /*
         * NOTE: arrays must be sorted
         *
         *  Binary Search: https://www.youtube.com/watch?v=atTOlifFGrg&list=PLeIMaH7i8JDjd21ZF6jlRKtChLttls7BG&index=3
         *
         * Ternary Search:  https://www.geeksforgeeks.org/ternary-search/
         */

        public int BinarySearch(int start, int end, int[] n, int k)
        {
            int mid = (start + end) / 2;

            if (k == n[mid]) return mid;

            if (k < n[mid])
                return BinarySearch(start, mid - 1, n, k);
            if (k > n[mid])
                return BinarySearch(mid + 1, end, n, k);
            return -1;
        }

        public int TernarySearch(int start, int end, int[] n, int k)
        {
            if (end >= start)
            {
                // do the n.Length - start to deal with overflow
                int mid1 = start + (end - start) / 3;
                int mid2 = end - (end - start) / 3;

                if (k == n[mid1]) return mid1;

                if (k == n[mid2]) return mid2;

                if (k < n[mid1])
                    return TernarySearch(start, mid1 - 1, n, k); // search in first third

                if (k > n[mid2])
                    return TernarySearch(mid2 + 1, end, n, k); // search in last third

                return TernarySearch(mid1 + 1, mid2 - 1, n, k); // search in second third
            }

            return -1;
        }
    }
}