using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    public class AddCommas
    {
        public string AddCommasInCorrectPlaces(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            if (str.Length <= 3) return str;
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
                s.Push(str[i]);

            int split = 0;
            StringBuilder sb = new StringBuilder();
            while (s.Count != 0)
            {
                sb.Append(s.Pop());
                split++;
                if (split == 3 && s.Count != 0)
                {
                    sb.Append(",");
                    split = 0;
                }
            }

            IEnumerable<char> xx = sb.ToString().Reverse();
            string yy = string.Join("", xx);
            return yy;
        }
    }
}