using System;
using System.Collections.Generic;
using System.Text;

namespace General
{
    public class BacktrackingDiceSum
    {
        public static void DiceSum(int diceCount, int desiredSum)
        {
            // https://www.youtube.com/watch?v=Frr8U5_TTtg&list=PLT0wqqmbAFnfdRRCnzqY943MDyaNa3KSy&index=9&t=0s
            /*
             * Two params: no of dice to roll, desired sum of all die output
             * Output: all combo of die values that add up to that sum
             * ex: DiceSum(2,7) = 1,6; 2,5; 3,4; 4,3; 5,2; 6,1
             */
            int x = 1;
            Console.WriteLine(x);
            List<int> list = new List<int>();
            DiceSumHelper(diceCount, desiredSum, list);
        }

        public static void DiceSumHelper(int diceCount, int desiredSum, List<int> output)
        {
            if (diceCount == 0)
            {
                if (desiredSum == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    output.ForEach(o => sb.Append(o + " "));
                    sb.Append("}");
                    Console.WriteLine(sb.ToString().Trim());
                }
            }
            else
            {
                // if there is at least one die, try all possible values (1 thru 6)
                for (int i = 1; i <= 6; i++)
                {
                    // choose i
                    output.Add(i);

                    // explore what could follow
                    DiceSumHelper(diceCount - 1, desiredSum - i, output);

                    // unchoose i
                    output.Remove(i);
                }
            }
        }
    }
}