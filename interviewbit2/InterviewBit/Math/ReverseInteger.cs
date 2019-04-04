namespace Math
{
    public class ReverseInteger
    {
        /*
         7. Reverse Integer https://leetcode.com/problems/reverse-integer/
        Easy

        Given a 32-bit signed integer, reverse digits of an integer.

        Example 1:

        Input: 123
        Output: 321

        Example 2:

        Input: -123
        Output: -321

        Example 3:

        Input: 120
        Output: 21

         */

        public int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                result = result * 10 + x % 10;
                x /= 10;
            }

            if (result >= int.MaxValue || result <= int.MinValue) return 0;

            return result;
        }
    }
}