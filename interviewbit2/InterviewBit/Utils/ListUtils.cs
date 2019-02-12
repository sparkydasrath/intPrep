using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class ListUtils
    {
        public static void PrintToConsole<T>(List<T> list)
        {
            StringBuilder sb = new StringBuilder();
            list.ForEach(o => sb.Append(o.ToString() + " "));
            Console.WriteLine(sb.ToString());
        }

        public static string PrintToString<T>(List<T> list)
        {
            StringBuilder sb = new StringBuilder();
            list.ForEach(o => sb.Append(o.ToString() + " "));
            return sb.ToString();
        }
    }
}