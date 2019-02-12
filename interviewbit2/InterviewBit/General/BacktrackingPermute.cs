using System.Collections.Generic;
using Utils;

namespace General
{
    public class BacktrackingPermute
    {
        public static void Permute(string s)
        {
            List<string> output = new List<string>();
            PermuteHelper(s, output);
        }

        public static void PermuteHelper(string s, List<string> output)
        {
            // Console.WriteLine($"permute s={s}, output={ListUtils.PrintToString(output)}"); base case
            if (s.Length == 0)
            {
                ListUtils.PrintToConsole(output);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    // choose
                    char c = s[i];
                    output.Add(c.ToString());
                    string nextChoices = s.Remove(i, 1);

                    // explore
                    PermuteHelper(nextChoices, output);

                    // un-choose basically undo what you did in the choose section
                    output.Remove(c.ToString());
                    string result = s.Insert(i, c.ToString());
                    // Console.WriteLine($"Inserting back result & s = {result}, {s}");
                }
            }
        }
    }
}