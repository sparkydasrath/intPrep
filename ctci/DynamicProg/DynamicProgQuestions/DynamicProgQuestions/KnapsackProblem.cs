using System;

namespace DynamicProgQuestions
{
    // https://www.youtube.com/watch?v=oTTzNMHM05I&list=PLDN4rrl48XKpZkf03iYFl-O29szjTrs_O&index=38
    public class KnapsackProblem
    {
        // assume cost and weight are sorted
        public int[] GetOptimal(int[] cost, int[] weight, int bagCapacity)
        {
            int weightCost = weight.Length;
            int sumOfWeights = bagCapacity + 1;

            int[,] k = new int[weightCost, sumOfWeights];

            for (int i = 0; i < weightCost; i++)
                for (int w = 0; w < sumOfWeights; w++)
                {
                    if (i == 0 || w == 0) k[i, w] = 0;
                    else if (weight[i] <= w)
                    {
                        k[i, w] = Math.Max(cost[i] + k[i - 1, w - weight[i]], k[i - 1, w]);
                    }
                    else k[i, w] = k[i - 1, w];
                }

            MatrixUtils.Print(k);

            return null;
        }
    }

    /*
     * Clearer explanation of how the algo works https://www.youtube.com/watch?v=sVAB0p58tlg
     *
     * Basically have a matrix where the rows are the weight/cost pair and the columns are the overall capacity
     * in increasing order
     *
     *  (px wt)     0   1   2   3   4       (total capacity = 4, in increasing order; SoW = Sum of Weights
     * ---------|-------------------
     *   1  1   |
     *   4  2   |                           (current weight being tested = 2)
     *   4  3   |                           (current weight being tested = 3)
     *
     *      ALGO:
     * if current_weight > sow
     *      copy value from directly above cell
     *
     * if current_weight <= sow
     *      max(value by excluding the new weight, value of including the new weight)
     *
     *  value by excluding the new weight:
     *      this is the value of the above cell
     *   value of including the new weight:
     *      1. include the new weight and its value
     *      2. for remaining weight, get value from above row & cell position (sow - w)
     *
     *
     */
}