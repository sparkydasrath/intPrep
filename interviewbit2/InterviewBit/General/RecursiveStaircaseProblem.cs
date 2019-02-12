namespace General
{
    public class RecursiveStaircaseProblem
    {
        /*
         *  https://www.youtube.com/watch?v=eREiwuvzaUM
         *  https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem
         *  assume max step size is 3
         */

        public int CountPathsMemoized(int steps)
        {
            int[] cache = new int[steps + 1];
            return CountPathsMemoizedHelper(steps, cache);
        }

        public int CountPathsMemoizedHelper(int steps, int[] cache)
        {
            if (steps < 0) return 0;
            if (steps == 0) return 1;
            if (cache[steps] == 0)
            {
                cache[steps] = CountPathsMemoizedHelper(steps - 1, cache) + CountPathsMemoizedHelper(steps - 2, cache) +
                               CountPathsMemoizedHelper(steps - 3, cache);
            }

            return cache[steps];
        }

        public int CountPathsRecursive(int steps)
        {
            if (steps < 0) return 0;
            if (steps == 0) return 1;
            int result = CountPathsRecursive(steps - 1) + CountPathsRecursive(steps - 2) +
                         CountPathsRecursive(steps - 3);

            return result;
        }
    }
}