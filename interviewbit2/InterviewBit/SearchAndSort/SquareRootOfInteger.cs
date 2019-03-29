namespace SearchAndSort
{
    public class SquareRootOfInteger
    {
        /*
         https://www.geeksforgeeks.org/square-root-of-an-integer/
         https://www.geeksforgeeks.org/find-square-root-number-upto-given-precision-using-binary-search/
           */

        // variable to store the answer
        private double ans;

        public double SquareRoot(int number, int precision)
        {
            int start = 0, end = number;

            // for computing integral part of square root of number
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (mid * mid == number)
                {
                    ans = mid;
                    break;
                }

                // incrementing start if integral part lies on right side of the mid
                if (mid * mid < number)
                {
                    start = mid + 1;
                    ans = mid;
                }

                // decrementing end if integral part lies on the left side of the mid
                else end = mid - 1;
            }

            // For computing the fractional part of square root up to given precision
            double increment = 0.1;
            for (int i = 0; i < precision; i++)
            {
                while (ans * ans <= number)
                    ans += increment;

                // loop terminates when ans * ans > number
                ans = ans - increment;
                increment = increment / 10;
            }
            return ans;
        }

        public int SquareRootSimple(int x)
        {
            // Base Cases
            if (x == 0 || x == 1)
                return x;

            // Do Binary Search for floor(sqrt(x))
            int start = 1, end = x, ans = 0;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                // If x is a perfect square
                if (mid * mid == x)
                    return mid;

                // Since we need floor, we update answer when mid * mid is smaller than x, and move
                // closer to sqrt(x)
                if (mid * mid < x)
                {
                    start = mid + 1;
                    ans = mid;
                }

                // If mid*mid is greater than x
                else
                    end = mid - 1;
            }
            return ans;
        }
    }
}