using System;
using System.Collections.Generic;

namespace InterviewTests
{
    public class Centerbridge
    {
        internal interface IMine
        {
            event Action MyEnvent;

            int MyProp { get; set; }
        }

        public class X
        {
            private string name;

            public string Name
            {
                get => name;
                set => name = value;
            }
        }

        public static int findParent(int processNumber) =>
            /*
* Complete the 'findParent' function below.
*
* The function is expected to return an INTEGER.
* The function accepts INTEGER processNumber as parameter.
*/
            0;

        public static string FirstRepeatedWord(string s)
        {
            HashSet<string> words = new HashSet<string>();

            char[] delim = { ' ', '\t', ',', ':', ';', '-', '.' };
            string[] splitWords = s.Split(delim);

            for (int i = 0; i < splitWords.Length; i++)
            {
                if (!words.Contains(splitWords[i]))
                    words.Add(splitWords[i]);
                else return splitWords[i];
            }

            return null;
        }

        private static int Minn(int x = 2, int y = 4, int z = 3) => Math.Min(x, Math.Min(y, z));

        public static IEnumerable<int> Power(int n, int e)
        {
            int res = 1;
            for (int i = 0; i < e; i++)
            {
                res = res * n;
                yield return res;
            }
        }
    }
}