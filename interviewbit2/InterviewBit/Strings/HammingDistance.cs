namespace Strings
{
    public class HammingDistance
    {
        // EASY
        /*
         461. Hamming Distance https://leetcode.com/problems/hamming-distance/
        Easy

        The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

        Given two integers x and y, calculate the Hamming distance.

        Note:
        0 ≤ x, y < 231.

        Example:

        Input: x = 1, y = 4

        Output: 2

        Explanation:
        1   (0 0 0 1)
        4   (0 1 0 0)
               ↑   ↑

        The above arrows point to positions where the corresponding bits are different.

         */

        public int HammingDistanceEasy(int x, int y)
        {
            // soln 1:
            /*
              return Convert.ToString(x ^ y, 2).Count(c => c == '1');
             */

            // soln 2
            int diff = x ^ y;
            int distance = 0;
            while (diff != 0)
            {
                diff = diff & diff - 1;
                distance++;
            }

            return distance;

            /*
             From comment:
             Thanks for this. Just a note for others who are as unfamiliar with bit shifting as I was:
             the subtraction operator - takes precedence over the logical AND operator &. In other words this line:

                diff = diff & diff - 1;

                    gets evaluated like this:

                diff = diff & (diff - 1);
             */
        }
    }
}