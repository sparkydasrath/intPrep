using System;
using System.Collections.Generic;
using System.Linq;

namespace mlp
{
    internal class Program
    {
        private static byte[] Encode(byte[] original)
        {
            List<byte> output = new List<byte>();
            byte count = 1;
            byte cur = original[0];
            for (int i = 1; i < original.Length; i++)
            {
                if (cur == original[i])
                {
                    count++;
                }
                else
                {
                    output.Add(count);
                    output.Add(cur);
                    count = 1;
                    cur = original[i];
                }
            }

            output.Add(count);
            output.Add(cur);

            byte[] actualOut = output.ToArray();
            return actualOut;
        }

        private static int[] FindMax(int[] numbers, int n)
        {
            // best approach
            Array.Sort(numbers);
            Array.Reverse(numbers);
            IEnumerable<int> res1 = numbers.Take(n).ToArray();

            // what I submitted
            List<int> list = numbers.ToList();
            list.Sort();
            list.Reverse();
            IEnumerable<int> res = list.Take(n);
            return res.ToArray();
        }

        private static void Main(string[] args)
        {
            MyEncoding myEncoding = new MyEncoding();
            string res = myEncoding.EncodeToBase62(int.MaxValue);
            Console.WriteLine(res);
            Console.WriteLine("\nmd5\n");

            string md5 = MyEncoding.MD5Hash("this is a test");
            Console.WriteLine(md5);
            Console.ReadLine();
        }

        private static void PlayWithLinq()
        {
            int[] n = { 5, 1, 10, 45, 3, 77, 2, 6, 9 };

            // filter
            IEnumerable<int> whereres = n.Where(i => i > 10); //45,77
        }

        private static int[] Sort(int[] numbers)
        {
            // best approach
            Array.Sort(numbers);
            return numbers;

            // bs approach
            List<int> list = numbers.ToList();
            list.Sort();
            return list.ToArray();
        }
    }
}