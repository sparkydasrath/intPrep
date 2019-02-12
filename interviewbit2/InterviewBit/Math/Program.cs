using System;
using System.Collections.Generic;

namespace Math
{
    internal class Program
    {
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2)
            {
                return true;
            }

            double limit = System.Math.Ceiling(System.Math.Sqrt(number)); //hoisting the loop limit

            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static Dictionary<int, int> Primes(int num)
        {
            Dictionary<int, int> p = new Dictionary<int, int>();

            for (int i = 2; i <= num; i++)
            {
                if (IsPrime(i))
                {
                    p.Add(i, i);
                }
            }

            return p;
        }

        public static List<int> primesum(int A)
        {
            // Dictionary<int, int> primes = Primes(A);
            Dictionary<int, int> primes = new Dictionary<int, int>();
            List<int> results = new List<int>();

            for (int i = 1; i <= A; i++)
            {
                if (IsPrime(i))
                {
                    if (!primes.ContainsKey(i))
                        primes.Add(i, i);

                    int next = A - i;

                    if (IsPrime(next) && !primes.ContainsKey(next))
                    {
                        primes.Add(next, next);
                        results.Add(i);
                        results.Add(next);
                    }
                }
            }

            return new List<int> { results[0], results[1] };
        }

        private static void Main(string[] args)
        {
            List<int> r = primesum(16777214);

            Console.ReadLine();
        }
    }
}