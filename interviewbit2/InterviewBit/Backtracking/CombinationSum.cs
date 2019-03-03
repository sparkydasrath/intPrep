using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class CombinationSum
    {
        private List<List<int>> results = new List<List<int>>();

        public List<List<int>> CombinationSumImp(int[] candidates, int target)
        {
            CombinationSumHelper(candidates, target, new List<int>(), 0);
            return results;
        }

        private void CombinationSumHelper(int[] candidates, int target, List<int> accumulator, int start)
        {
            if (accumulator.Sum() == target)
            {
                results.Add(accumulator);
                return;
                ;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target)
                    CombinationSumHelper(candidates, target, new List<int>(accumulator), i);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        private void CombinationSumHelper2(int[] candidates, int target, List<int> accumulator, int start)
        {
            //combo sum 2
            // see LC
            if (accumulator.Sum() == target)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target)
                    CombinationSumHelper(candidates, target, new List<int>(accumulator), i + 1);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }

        private void CombinationSumHelper3(int[] candidates, int target, List<int> accumulator, int start, int k)
        {
            //combo sum 2
            // see LC
            if (accumulator.Sum() == target && accumulator.Count == k)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                accumulator.Add(candidates[i]);

                if (accumulator.Sum() <= target && accumulator.Count <= k)
                    CombinationSumHelper(candidates, target, new List<int>(accumulator), i + 1);

                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }
    }
}