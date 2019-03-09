namespace Math
{
    public class UglyNumber
    {
        /*
         263. Ugly Number https://leetcode.com/problems/ugly-number/
        Easy

        Write a program to check whether a given number is an ugly number.

        Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.

        Example 1:

        Input: 6
        Output: true
        Explanation: 6 = 2 × 3

        Example 2:

        Input: 8
        Output: true
        Explanation: 8 = 2 × 2 × 2

        Example 3:

        Input: 14
        Output: false
        Explanation: 14 is not ugly since it includes another prime factor 7.

        Note:

            1 is typically treated as an ugly number.
            Input is within the 32-bit signed integer range: [−231,  231 − 1].

        https://www.geeksforgeeks.org/ugly-numbers/
         */

        public int GetNthUglyNo(int n)
        {
            /*
              The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers.
              By convention, 1 is included.
             */
            int i = 1;

            // ugly number count
            int count = 1;

            // check for all integers until count becomes n
            while (n > count)
            {
                i++;
                if (IsUgly(i))
                    count++;
            }
            return i;
        }

        public int GetNthUglyNoDp(int n)
        {
            // To store ugly numbers
            int[] ugly = new int[n];
            int i2 = 0, i3 = 0, i5 = 0;
            int nextMultipleOf2 = 2;
            int nextMultipleOf3 = 3;
            int nextMultipleOf5 = 5;
            int nextUglyNo = 1;

            ugly[0] = 1;

            for (int i = 1; i < n; i++)
            {
                nextUglyNo = System.Math.Min(nextMultipleOf2, System.Math.Min(nextMultipleOf3, nextMultipleOf5));

                ugly[i] = nextUglyNo;

                if (nextUglyNo == nextMultipleOf2)
                {
                    i2 = i2 + 1;
                    nextMultipleOf2 = ugly[i2] * 2;
                }

                if (nextUglyNo == nextMultipleOf3)
                {
                    i3 = i3 + 1;
                    nextMultipleOf3 = ugly[i3] * 3;
                }
                if (nextUglyNo == nextMultipleOf5)
                {
                    i5 = i5 + 1;
                    nextMultipleOf5 = ugly[i5] * 5;
                }
            }

            return nextUglyNo;
        }

        public bool IsUgly(int num)
        {
            num = MaxDivide(num, 2);
            num = MaxDivide(num, 3);
            num = MaxDivide(num, 5);

            return num == 1;
        }

        /*This function divides a by greatest divisible power of b*/

        private int MaxDivide(int a, int b)
        {
            while (a % b == 0)
                a = a / b;
            return a;
        }
    }
}