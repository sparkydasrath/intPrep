using System.Threading.Tasks;

namespace InterviewTests
{
    public class Multiply
    {
        private int result;

        public int MultiplyIterative(int a, int b)
        {
            int result = 0;
            if (a == 0 || b == 0) return 0;

            for (int i = 0; i < b; i++)
                result += a;

            return result;
        }

        public int MultiplyRecursive(int a, int b)
        {
            MultiplyRecursiveHelper(a, b, 0);
            return result;
        }

        public void MultiplyRecursiveHelper(int a, int b, int count)
        {
            if (count == b) return;

            result += a;
            MultiplyRecursiveHelper(a, b, count + 1);
        }
    }

    public class Talan
    {
        // private readonly double x = -3.14; private readonly int y = (int)Math.Abs(x);

        // float i = 1.0f; float j = 0.05f;
        //
        // while (i < 2.0f && j <= 2.0f) { Console.WriteLine(i++ - ++j); }
        //
        // Program p = new Program(); Console.WriteLine(p.Mf(4));

        // string s1 = "ALL MEN ARE CREATED EQUAL"; Console.WriteLine(s1.Substring(12, 3));

        // SaySomething();

        /*List<Action> p = new List<Action>();

        for (int i = 0; i < 10; i++)
        {
            p.Add(delegate { Console.WriteLine(i); });
        }

        foreach (Action action in p)
        {
            action();
        }*/

        private static async Task<string> SaySomething()
        {
            await Task.Delay(1);
            return "something";
        }

        private int Mf(int n)
        {
            if (n == 1) return 1;
            int result = Mf(n - 1) * n;
            return result;
        }
    }
}