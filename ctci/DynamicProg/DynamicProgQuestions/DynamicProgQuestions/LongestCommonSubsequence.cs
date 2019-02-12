using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgQuestions
{
    public class LongestCommonSubsequence
    {
        private readonly string a;
        private readonly string b;
        private readonly List<string> rRecursive;

        public LongestCommonSubsequence()
        {
            rRecursive = new List<string>();
            a = "babce" + '\0';
            b = "abdace" + '\0';
        }

        public List<string> GetAllSubsequencesNaive(string a, string b)
        {
            List<string> r = new List<string>();
            int skip = 0;
            int take = b.Length;

            while (take > 0)
            {
                char[] toTake = b.Skip(skip).Take(take).ToArray();
                string next_b = new string(toTake);
                string val = GetLcsNaive(a, next_b);

                r.Add(val);

                skip++;
                take--;
            }

            int max = r.Max(x => x.Length);

            return r;
        }

        public string GetLcsNaive(string a, string b)
        {
            string s = null;
            int jNext = 0;

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = jNext; j < a.Length; j++)
                {
                    if (b[i] == a[j])
                    {
                        s += b[i];
                        jNext = j;
                        break;
                    }
                }
            }

            return s;
        }

        public int GetLcsRecursive(int i, int j)
        {
            if (a[i] == '\0' || b[j] == '\0') return 0;
            if (a[i] == b[j]) return 1 + GetLcsRecursive(i + 1, j + 1);
            return Math.Max(GetLcsRecursive(i + 1, j), GetLcsRecursive(i, j + 1));
        }
    }
}