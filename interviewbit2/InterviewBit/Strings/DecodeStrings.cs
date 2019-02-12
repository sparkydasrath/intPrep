using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class DecodeStrings
    {
        public string DecodeStringDfs(string s)
        {
            Queue<char> q = new Queue<char>();
            foreach (char c in s) q.Enqueue(c);
            return DecodeStringDfsHelper(q);
        }

        public string DecodeStringWithList(string s)
        {
            int curNum = 0;
            int multiplier = 0;
            string curString = "";
            List<string> stack = new List<string>();
            foreach (char c in s)
            {
                if (c == '[')
                {
                    /*
                     * this indicates we are starting a new sequence so first save what we
                     * have already computed to the list
                     */
                    stack.Add(curString);
                    stack.Add(curNum.ToString());
                    curString = ""; // reset curString since its backed up in the list
                    curNum = 0;
                }
                else if (c == ']')
                {
                    //restore the number that this sequence needs to be repeated
                    int num = int.Parse(GetStoredStringFromList(stack));
                    // restore the previously computed string from the list
                    string prevString = GetStoredStringFromList(stack);
                    string mulString = "";
                    for (int counter = num; counter > 0; counter--)
                        mulString += curString;
                    curString = prevString + mulString;
                }
                else if (int.TryParse(c.ToString(), out multiplier))
                {
                    curNum = curNum * 10 + multiplier;
                }
                else
                {
                    curString += c;
                }
            }

            return curString;
        }

        public string GetStoredStringFromList(List<string> stack)
        {
            // at any time the list will only store the number a sequence needs to be repeated and
            // the last computed sequence
            string popped = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return popped;
        }

        private string DecodeStringDfsHelper(Queue<char> q)
        {
            StringBuilder sb = new StringBuilder();
            int multiplier = 0;

            while (q.Count != 0)
            {
                char c = q.Dequeue();

                if (c == '[')
                {
                    string temp = DecodeStringDfsHelper(q);
                    for (int i = 0; i < multiplier; i++)
                        sb.Append(temp);
                    multiplier = 0;
                }
                else if (c == ']')
                {
                    break; // end recursive call
                }
                else if (char.IsDigit(c)) // is it a digit
                {
                    multiplier = multiplier * 10 + c - '0';
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}