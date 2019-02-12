using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class SumStringAndNumber
    {
        public string ComputeSum(string str, int num)
        {
            /* case 1: "123" + "4" => "127"
             case 2: "128" + "4" => "132"
             case 3: "999" + "1" => "1000"
            */

            StringBuilder sb = new StringBuilder();
            Stack<int> s = new Stack<int>();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                // int charAsNum = str[i] - '0';
                int charAsNum = (int)char.GetNumericValue(str[i]);
                int partialSum = charAsNum + num;
                int div = partialSum / 10;
                int rem = partialSum % 10;
                s.Push(rem);
                num = div;

                if (i == 0 && num != 0)
                {
                    s.Push(num);
                }
            }

            while (s.Count != 0)
            {
                sb.Append(s.Pop());
            }

            string result = sb.ToString();
            return result;
        }
    }
}