using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class PrintDuplicateCharacters
    {
        public string GetDuplicates(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!dictionary.ContainsKey(c)) dictionary[c] = 1;
                else dictionary[c]++;
            }

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<char, int> kvp in dictionary)
                if (kvp.Value > 1) sb.Append(kvp.Key);

            return sb.ToString();
        }
    }
}