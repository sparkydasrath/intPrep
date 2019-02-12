using System.Collections.Generic;

namespace Math
{
    public class Primes
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

        public static List<int> PrimeSum(int a)
        {
            // https://www.interviewbit.com/problems/prime-sum/ exceeded timelimit with : input = 16777214
            Dictionary<int, int> primes = new Dictionary<int, int>();
            List<int> results = new List<int>();

            for (int i = 1; i <= a; i++)
            {
                if (IsPrime(i))
                {
                    if (!primes.ContainsKey(i))
                        primes.Add(i, i);

                    int next = a - i;

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
    }
}