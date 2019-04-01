using System;
using System.Collections;
using System.Linq;

namespace InterviewTests
{
    public delegate void EditHandler(object sender, EditHandlerArgs args);

    internal delegate int Cal(int m, int n);

    public class Comp
    {
        private readonly int a = 1;
        public int NumberOfTimes { get; set; }

        public void Mix(ref int counter, params Comp[] cpos) => counter++;
    }

    public class EditHandlerArgs : EventArgs
    {
    }

    public class Norgate
    {
        public event EditHandler Changed;

        public static void Run()
        {
            Cal c = new Cal((n, m) => n + m);
            c += new Cal((n, m) => n + m);
            Console.WriteLine(c(c(2, 5), 4));
        }

        public static object StartList(object[] arr)
        {
            foreach (object o in arr)
            {
                if (o is IEnumerable)
                {
                    return ((IEnumerable)o).GetEnumerator();
                }
            }

            return Enumerable.Range(0, 4).GetEnumerator();
        }
    }
}