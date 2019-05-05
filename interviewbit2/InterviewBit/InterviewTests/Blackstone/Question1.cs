using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTests.Blackstone
{
    public class Question1
    {
        /*
         Programming Challenge Description:
            Given two arrays of integers, A1 and A2, find all elements in A2 that are not in A1.
            Comment on the computational complexity of your answer.
            Input:
            A space seperated list of integers for Array 1, a new line, A space separated list of integers for array 2, a new line.
            Output:
            A space separated list of integers.

            MAIN method for this prob:

                private static void Main(string[] args)
                {
                    string l1 = string.Empty;
                    string l2 = string.Empty;

                    using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                        while (!reader.EndOfStream)
                        {
                            l1 = reader.ReadLine();
                            l2 = reader.ReadLine();

                            if (l1 != string.Empty && l2 != string.Empty)
                            {
                                Question1 q1 = new Question1();
                                string results = q1.FindUncommonElements(l1, l2);
                                Console.WriteLine(results);
                            }
                        }
                }

         */

        public string FindUncommonElements(string input1, string input2)
        {
            List<int> list1 = ParseInput(input1);
            List<int> list2 = ParseInput(input2);

            IEnumerable<int> intersect = list1.Intersect(list2);

            List<int> results = list2;

            foreach (int num in intersect)
            {
                if (results.Contains(num))
                    results.Remove(num);
            }

            // shorter
            //List<int> res2 = list2.Except(list1).ToList();

            return string.Join(" ", results);
        }

        private List<int> ParseInput(string input1)
        {
            List<int> results = new List<int>();
            string[] split = input1.Split(' ');
            foreach (var s in split)
                results.Add(Convert.ToInt32(s));

            return results;
        }
    }
}