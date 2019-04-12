using System.Collections.Generic;
using System.Linq;

namespace Facebook
{
    public class BasicCalculator2
    {
        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            int curNum = 0;
            char currSign = '+';
            s = s.Replace(" ", "");

            for (int i = 0; i < s.Length; i++)
            {
                char curr = s[i];
                if (curr == ' ') continue;

                if (char.IsDigit(curr))
                {
                    /*
                    If the current item is a number, just convert the char to a number
                    and use it later based on the sign
                    */
                    curNum = curNum * 10 + curr - '0';
                }

                if (!char.IsDigit(curr) || i == s.Length - 1)
                {
                    // at this point the char has to be a digit and the next char is sign

                    if (currSign == '+')
                    {
                        stack.Push(curNum);
                    }

                    if (currSign == '-')
                    {
                        stack.Push(-curNum);
                    }

                    if (currSign == '*')
                    {
                        // this takes precedence to pop whatever was in stack and compute new value
                        stack.Push(stack.Pop() * curNum);
                    }

                    if (currSign == '/')
                    {
                        // this takes precedence to pop whatever was in stack and compute new value
                        stack.Push(stack.Pop() / curNum); // will automatically do rounding division
                    }

                    currSign = curr;
                    curNum = 0;
                }
            }
            return stack.Sum();
        }
    }
}