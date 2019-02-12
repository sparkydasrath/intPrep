namespace General

{
    public class RecursionPowerOfNumbers
    {
        public static int Power(int x, int n)
        {
            if (n == 0) return x;
            return x * Power(x, n - 1);
        }
    }
}