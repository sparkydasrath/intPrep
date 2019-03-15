using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays.Tests
{
    public class AddOne
    {
        /*
            Write a program which takes as input an array of digits encoding a decimal number
            D and updates the array to represent the number D + 1. For example, if the input
            is (1,2,9) then you should update the array to (1,3,0). Your algorithm should work
            even if it is implemented in a language that has finite-precision arithmetic.
         */

        public List<int> AddOneToDecimalNumberInAList(List<int> nums)
        {
            // add 1 to the last element (the 1s column)
            nums[nums.Count - 1]++;

            if (nums[nums.Count - 1] < 10) return nums;

            // this is a case where we get potential carry on each add
            for (int i = nums.Count - 1; i > 0 && nums[i] == 10; i--)
            {
                // this loop only runs while when adding 1 to the value at the i-th index, we get 10
                // at this point, we know for a fact that we have a 10 so the only possible value for
                // this index is 0 (means we have a carry)

                nums[i] = 0;
                nums[i - 1] = nums[i - 1] + 1; // add the carry to the next item in the list, moving right to left
            }

            if (nums[0] == 10)
            {
                // this means we carried a 1 all the way to the end of the list BUT also this list is
                // too short
                // ex: starting is {9,9} ==> should result in {1,0,0}
                /*
                        index   0   1
                    --------------------
                    first pass: 9   9+1 ==> 9   10
                        ->      9+1  0
                            (this +1 is from the carry in pass 1)
                 */
                nums[0] = 0;
                nums.Insert(0, 1);
            }
            return nums;
        }

        public string AddTwoBinaryNumbersInAList(string s, string t)
        {
            /*
             Variant: Write a program which takes as input two strings s and t of bits encoding
            binary numbers Bs and Bt, respectively, and returns a new string of bits representing
            the number Bs + Bt
             */

            if (t.Length > s.Length)
                AddTwoBinaryNumbersInAList(t, s); // always have longer string before

            if (s.Length != t.Length)
            {
                // at this point we know the shorter string the second one and we need to pad it
                int padLength = s.Length - t.Length;
                int i = 0;
                StringBuilder sb = new StringBuilder();
                while (i < padLength)
                {
                    sb.Append("0");
                    i++;
                }

                t = sb + t;
            }

            List<int> results = Enumerable.Repeat(0, s.Length).ToList();
            int carry = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int v = s[i] - '0' + t[i] - '0' + carry;
                if (v > 1)
                {
                    results[i] = 0;
                    carry = 1;
                }
                else if (v == 1)
                {
                    results[i] = v;
                    carry = 0;
                }
                else
                {
                    results[i] = carry;
                    carry = 0;
                }

                v = 0;
            }

            if (carry != 0)
                results.Insert(0, carry);

            return string.Join("", results);
        }
    }
}