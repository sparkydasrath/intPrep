using System.Collections.Generic;
using System.Linq;

namespace Math
{
    public class Factors
    {
        public static int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return Gcd(b, a % b);
        }

        public static List<int> GetAllFactorsOf(int a)
        {
            List<int> result = new List<int>();

            int sqrt = (int)System.Math.Sqrt(a);
            if (System.Math.Sqrt(a) % 1 != 0)
            {
                sqrt = (int)System.Math.Ceiling(System.Math.Sqrt(a));
            }

            for (int i = 1; i <= sqrt; i++)
            {
                if (a % i == 0)
                {
                    result.Add(i);
                    if (i != System.Math.Sqrt(a))
                    {
                        result.Add(a / i);
                    }
                }
            }

            List<int> dist = result.Distinct().ToList();
            dist.Sort();

            // if (dist.Count == 2 && dist[0] == 1 && dist[1] == A) return 1; else return 0;

            return dist;
        }
    }
}