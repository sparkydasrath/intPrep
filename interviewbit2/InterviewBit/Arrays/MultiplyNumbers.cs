using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class MultiplyNumbers
    {
        /*
        Write a program that takes two arrays representing integers, and re¬
        turns an integer representing their product. For example, since
        193707721 X -761838257287 = -147573952589676412927, if the inputs are
        (1,9,3, 7,0,7, 7, 2,1} and (-7,6,1,8,3,8, 2,5,7, 2,8, 7), your function should return
        (-1,4, 7,5,7,3, 9,5, 2,5,8, 9,6, 7,6, 4,1, 2, 9, 2,7).
        Hint: Use arrays to simulate the grade-school multiplication algorithm

        Solution:
        As in Solution 6.2 on Page 65, the possibility of overflow precludes us from
        converting to the integer type.
        Instead we can use the grade-school algorithm for multiplication which consists
        of multiplying the first number by each digit of the second, and then adding all the
        resulting terms.

        From a space perspective, it is better to incrementally add the terms rather than
        compute all of them individually and then add them up. The number of digits
        required for the product is at most n + m for n and m digit operands, so we use an
        array of size n+ m for the result.

        For example, when multiplying 123 with 987, we would form 7 X 123 = 861, then
        we would form 8 X 123 X 10 = 9840, which we would add to 861 to get 10701. Then
        we would form 9 X 123 X 100 = 110700, which we would add to 10701 to get the final
        result 121401. (All numbers shown are represented using arrays of digits.)

            Can't get this mofo to work

         */

        public List<int> MultipleTwoNumbers(List<int> num1, List<int> num2)
        {
            // if (num2.Count > num1.Count) MultipleTwoNumbers(num2, num1); 3 slots + 3 slots = 6
            // slots in results
            // ex: 123 * 987 = 110700 so the result will be as long as the sum of the two list lengths
            List<int> results = Enumerable.Repeat(0, num1.Count + num2.Count).ToList();

            // final signage of result
            int sign = 1;
            if (num1[0] < 0 && num2[0] < 0) sign = 1;
            else sign = -1;

            // make negative numbers all positive
            num1[0] = Math.Abs(num1[0]);
            num2[0] = Math.Abs(num2[0]);

            for (int i = num1.Count - 1; i >= 0; i--)
            {
                for (int j = num2.Count - 1; j >= 0; j--)
                {
                    results[i + j + 1] = results[i + j + 1] + num1[i] * num2[j];
                    results[i + j] = results[i + j] + results[i + j + 1] / 10;
                    results[i + j + 1] = results[i + j + 1] % 10;
                }
            }

            results[0] *= sign;

            return results;
        }
    }
}