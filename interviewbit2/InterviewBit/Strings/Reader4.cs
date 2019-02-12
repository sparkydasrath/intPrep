using System;
using System.Collections.Generic;
using System.Linq;

namespace Strings
{
    public class Reader4
    {
        // assume we have this magic class with the read4 method that returns the count of chars read
        // from a file

        private readonly List<char> temp = GetChars();

        public int Read4(char[] buf)
        {
            List<char> take = temp.Take(4).ToList();

            for (int i = 0; i < take.Count; i++)
            {
                buf[i] = take[i];
            }

            temp.RemoveRange(0, temp.Count >= 4 ? 4 : temp.Count);
            return take.Count();
        }

        private static List<char> GetChars()
        {
            List<char> temp = new List<char>();
            for (int i = 97; i < 102; i++)
                temp.Add(Convert.ToChar(i));

            return temp;
        }
    }
}